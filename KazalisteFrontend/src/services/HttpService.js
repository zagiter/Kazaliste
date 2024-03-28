import axios from "axios";


export const HttpService = axios.create({

    baseURL: 'https://zagiter-001-site1.ftempurl.com/api/v1',
    headers: {
        'Content-Type' : 'application/json'
    }


});