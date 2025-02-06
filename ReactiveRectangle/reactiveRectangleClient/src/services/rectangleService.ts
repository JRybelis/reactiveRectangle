import axios from 'axios';
import { Rectangle, ValidationResponse } from '../types/rectangle';

const API_URL = 'http://localhost:5071/api';

export const validateRectangle = async (dimensions: Rectangle): 
Promise<ValidationResponse> => {
    const { data } = await axios.post(`${API_URL}/rectangle/validate`, dimensions);
    return data;
};