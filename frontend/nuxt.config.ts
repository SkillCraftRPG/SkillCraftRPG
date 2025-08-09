import pkg from "./package.json";

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: "2025-05-15",
  devtools: { enabled: true },
  modules: ["usebootstrap", "@nuxtjs/i18n"],
  css: ["@fortawesome/fontawesome-svg-core/styles.css", "~/assets/styles/main.css"],
  app: {
    head: {
      link: [
        { rel: "icon", href: "/favicon.ico" },
        { rel: "icon", type: "image/png", sizes: "32x32", href: "/favicon-32.png" },
        { rel: "apple-touch-icon", href: "/favicon-180.png" },
      ],
    },
  },
  i18n: {
    defaultLocale: "fr",
    locales: [{ code: "fr", name: "French" }],
  },
  runtimeConfig: {
    public: {
      apiBaseUrl: "http://localhost:8088",
      baseUrl: "http://localhost:3000",
      version: pkg.version,
    },
  },
});
