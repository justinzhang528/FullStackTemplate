import axios from 'axios'
import { baseURL_stg } from '@/config/baseURL'

const request = axios.create({
    baseURL: baseURL_stg,
    timeout: 10000
});

// get請求
export const $get = async (url: string, params: any) => {
    return await request.get(url, { params });
}

// post請求
export const $post = async (url: string, data: any) => {
    return await request.post(url, data);
}