window.onload = function () {
    fetch('/api/users')
        .then(response => response.json())
        .then(data => {
            const userList = document.getElementById('userList');
            data.forEach(user => {
                const li = document.createElement('li');
                li.textContent = user;
                userList.appendChild(li);
            });
        });
};