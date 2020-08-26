import axios from 'axios';

const api = axios.create({
    baseURL: 'https://pb-8.azurewebsites.net/api',
})

export default api;