import api from '../api';

export const login = async (username, password) => {
    const res = await api.post('https://localhost:7178/api/Profiles', {
        username, password
    });
    return res.data;
};
