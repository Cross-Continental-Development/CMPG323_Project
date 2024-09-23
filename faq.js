import('node-fetch').then(({ default: fetch }) => {
    const faqUrl = 'http://localhost:8080/FAQ.php'; // Replace with your PHP script URL
    fetch(faqUrl)
        .then(response => {
            if (response.headers.get('Content-Type') !== 'application/json') {
                throw new Error('Invalid response format. Expected JSON, got ' + response.headers.get('Content-Type'));
            }
            return response.json();
        })
        .then(data => {
            // Update HTML FAQ page
            const faqContainer = document.getElementById('faq-container');
            data.forEach(item => {
                const QUESTION = document.createElement('h2');
                QUESTION.textContent = `Q: ${item.question}`;
                faqContainer.appendChild(QUESTION);

                const ANSWER = document.createElement('p');
                ANSWER.textContent = `A: ${item.answer}`;
                faqContainer.appendChild(ANSWER);
            });
        })
        .catch(error => console.error('Error:', error));
});