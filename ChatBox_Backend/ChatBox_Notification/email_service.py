import os
from typing import List
from dotenv import load_dotenv
from pydantic import BaseModel
from fastapi import APIRouter, HTTPException
from mailjet_rest import Client
from celery import Celery

# 載入環境變數
load_dotenv()

# 建立 fastapi
router = APIRouter()

# celery 設定
celery_email = Celery(
    "email_tasks",
    broker="redis://localhost:6379/0"
)

# 從環境變數取得 Mailjet api 憑證
MAILJET_API_KEY = os.getenv("MAILJET_API_KEY")
MAILJET_SECRET_KEY = os.getenv("MAILJET_SECRET_KEY")
mailjet = Client(auth=(MAILJET_API_KEY, MAILJET_SECRET_KEY), version='v3.1')

# email 資料
class EmailPayload(BaseModel):
    to: List[str]
    subject: str
    html: str
    text: str
    from_email: str
    from_name: str

# 寄送信件 api
@router.post("/token")
async def send_email(payload: EmailPayload):
    try:
        send_email_task.delay(
            payload.to,
            payload.subject,
            payload.html,
            payload.text,
            payload.from_email,
            payload.from_name,
        )
        return {"success": True, "message": "Email sending queued."}
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Queue email failed: {str(e)}")

@celery_email.task
def send_email_task(to, subject, html, text, from_email, from_name):
    data = {
        'Messages': [{
            "From": {
                "Email": from_email,
                "Name": from_name
            },
            "To": [{"Email": email} for email in to],
            "Subject": subject,
            "TextPart": text,
            "HTMLPart": html
        }]
    }

    result = mailjet.send.create(data=data)
    if result.status_code != 200:
        raise Exception(f"Mailjet send failed: {result.status_code} {result.json()}")