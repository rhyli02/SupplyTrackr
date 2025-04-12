const axios = require('axios')

const API_BASE_URL = "https://localhost:7178"

export const api = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        "Content-Type" : "application/json"
    },
});
