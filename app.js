document.getElementById('loginBtn').addEventListener('click', () => {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    
    // Here you would usually send the username and password to the server for validation.
    // For this example, we'll just check against hardcoded values.
    if(username === "admin" && password === "password123") {
        document.getElementById('loginForm').style.display = 'none';
        document.getElementById('controlPage').style.display = 'block';
    } else {
        alert("Incorrect username or password!");
    }
});

document.getElementById('generateAppBuild').addEventListener('click', () => {
    fetch('/generateAppBuild', {
        method: 'POST'
    })
    .then(response => response.json())
    .then(data => {
        if(data.success) {
            alert("Generated new app build successfully!");
        } else {
            alert("Failed to generate new app build.");
        }
    });
});


document.getElementById('backupFiles').addEventListener('click', () => {
    fetch('/backupDatabase', {
        method: 'POST'
    })
    .then(response => response.json())
    .then(data => {
        if(data.success) {
            alert("Database backup successful with old Build# " + data.buildNumber);
        } else {
            alert("Failed to backup the database.");
        }
    });
});

document.getElementById('pushClientUpdate').addEventListener('click', () => {
    fetch('/pushClientUpdate', {
        method: 'POST'
    })
    .then(response => response.json())
    .then(data => {
        if(data.success) {
            alert("Pushed client update successfully!");
        } else {
            alert("Failed to push client update.");
        }
    });
});


