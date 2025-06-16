<!--網頁共用部分-->
<template>
    <div class="min-h-screen flex flex-col bg-gradient-to-br from-sky-100 to-indigo-100 text-gray-800 font-sans">
        <Navbar />
        <main class="flex-grow flex items-center justify-center px-4 py-6">
            <div class="max-w-4xl mx-auto w-full">
                <RouterView />
            </div>
        </main>
        <Footer />
    </div>
</template>

<script setup lang="ts">
import Navbar from './components/shared/Navbar.vue'
import Footer from './components/shared/Footer.vue'
</script>

<style>
html {
    overflow-y: scroll;
}
</style>