<template>
    <div class="w-full max-w-3xl mx-auto p-8 space-y-10 text-center">
        <div>
            <h1 class="text-4xl md:text-5xl font-bold leading-tight">Welcome to Chatbox</h1>
            <p class="mt-4 text-lg text-gray-700">Your all-in-one messaging platform to connect, collaborate, and stay productive.</p>
        </div>

        <div class="flex justify-center">
            <img src="@/assets/messages.svg" class="w-60 md:w-80 h-auto object-contain"/>
        </div>

        <div class="flex justify-center gap-4">
            <RouterLink to="/login">
                <button class="bg-indigo-600 text-white px-6 py-3 rounded-xl shadow hover:bg-indigo-700 transition">Login</button>
            </RouterLink>

            <RouterLink to="/register">
                <button class="bg-white bg-opacity-80 text-gray-800 px-6 py-3 rounded-xl shadow hover:bg-opacity-100 transition">Register</button>
            </RouterLink>
        </div>
    </div>
</template>
