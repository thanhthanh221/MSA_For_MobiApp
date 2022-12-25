function isValidEmail(value) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(value).toLowerCase());
}

function validateEmail(value, setEmailError) {
    if (value == "") {
        setEmailError("")
    }
    else if (isValidEmail(value)) {
        setEmailError("")
    }
    else {
        setEmailError("Không phải Email")
    }
}

function validatePassword(value, setPasswordError, comparativeValue) {
    if (value.trim().length < 6) {
        setPasswordError("Mật khẩu quá ngắn")
    }
    else if (comparativeValue && value !== comparativeValue) {
        setPasswordError("Mật khẩu không trùng khớp")
    }
    else {
        setPasswordError("")
    }
}

function validateInput(value, minLength, setError) {
    if (value.length < minLength) {
        setError("Không đúng.")
    } else {
        setError("")
    }
}

function calculateAngle(coordinates) {
    let startLat = coordinates[0]["latitude"]
    let startLng = coordinates[0]["longitude"]
    let endLat = coordinates[1]["latitude"]
    let endLng = coordinates[1]["longitude"]
    let dx = endLat - startLat
    let dy = endLng - startLng

    return Math.atan2(dy, dx) * 180 / Math.PI
}

const utils = {
    isValidEmail,
    validateEmail,
    validatePassword,
    calculateAngle,
    validateInput
}
export default utils