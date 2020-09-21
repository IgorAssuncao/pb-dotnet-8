import axios from 'axios';

const api = axios.create({
    baseURL: 'https://pb-8.azurewebsites.net/api',
    headers: {
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
        'Content-Type': 'application/json'
    }
})

export default api;