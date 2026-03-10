import axios from "axios";

const API_URL = '/api/payment';
const API_KEY = "SuperSecretKey123"
export const createPayment = async (payment, apiKey) => {
    const response = await axios.post(API_URL, payment, {
        headers: {
            'Api-Key': apiKey
        }
    });
    return response.data;
}

export const paymentStats = async () => {
    const response = await axios.get(`${API_URL}/stats`, {
        headers: {
            'Api-Key': API_KEY
        }
    });
    return response.data;
}

export const paymentHistory = async () => {
    const response = await axios.get(API_URL, {
        headers: {
            'Api-Key': API_KEY
        }
    });
    return response.data;
}
