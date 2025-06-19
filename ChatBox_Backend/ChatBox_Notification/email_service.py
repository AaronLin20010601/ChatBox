from fastapi import APIRouter, HTTPException
from pydantic import BaseModel
from typing import List
from mailjet_rest import Client
import os
from dotenv import load_dotenv

# 載入環境變數
load_dotenv()

# 建立 fastapi
router = APIRouter()

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
        data = {
            'Messages': [{
                "From": {
                    "Email": payload.from_email,
                    "Name": payload.from_name
                },
                "To": [{"Email": email} for email in payload.to],
                "Subject": payload.subject,
                "TextPart": payload.text,
                "HTMLPart": payload.html
            }]
        }

        result = mailjet.send.create(data=data)

        if result.status_code != 200:
            raise HTTPException(
                status_code=result.status_code,
                detail=result.json()
            )

        return {
            "success": True,
            "status": result.status_code,
            "body": result.json()
        }

    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Sending mail failed: {str(e)}")