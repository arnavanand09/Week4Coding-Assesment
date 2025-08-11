function isPrime(number) {
    if (number < 2) {
        return false; 
    }
    for (let i = 2; i < number; i++) {
        if (number % i === 0) {
            return false; 
        }
    }
    return true; 
}

function checkPrime() {
    const input = document.getElementById('numberInput').value;
    const number = parseInt(input, 10);
    const result = document.getElementById('result');

    if (isNaN(number)) {
        result.textContent = "Please enter a valid number.";
        return;
    }

    if (isPrime(number)) {
        result.textContent = number + " is a prime number.";
    } else {
        result.textContent = number + " is not a prime number.";
    }
}