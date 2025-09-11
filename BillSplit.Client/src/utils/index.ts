import * as CryptoJS from 'crypto-js';

const SECRET_KEYData='7fh74df^%%sdkfj#23@';
export const encodeData = (data: any) => {
    if (!data) {
        return false;
    }
    const encrypted = CryptoJS.AES.encrypt(data, SECRET_KEYData);
    const encrypteData = encrypted.toString();
    return encrypteData;
};

// Decode Data Function
export const decodeData = (data: any) => {
    if (!data) {
        return false;
    }
    try {
        const bytes = CryptoJS.AES.decrypt(data, SECRET_KEYData);
        const decryptedJson = bytes.toString(CryptoJS.enc.Utf8);
        return JSON.parse(decryptedJson);
    } catch (error) {
        console.error('Decryption error:', error);
        return null;
    }
};
export const setLocalStorage = (data: any) => {
    console.log('Data---->', data);

    if (data) {
        const dataString = JSON.stringify(data);
        const val = encodeData(dataString);
        localStorage.setItem('J4AmJ8FBk0FydwuiJMTwgkQq6', `${val}`);
    }
};

export const getLocalStorage = () => {
    const data = localStorage.getItem('J4AmJ8FBk0FydwuiJMTwgkQq6');
    return decodeData(data);
};

export const removeLocalStorage = () => {
    localStorage.removeItem('J4AmJ8FBk0FydwuiJMTwgkQq6');
    return null;
};
