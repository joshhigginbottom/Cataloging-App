import axios from 'axios';

export default axios.create({
        baseURL:'https://localhost:7138/api/',
        withCredentials: false,
    });