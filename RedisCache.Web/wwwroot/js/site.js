document.getElementById('storeForm').addEventListener('submit', function () {
    const btnText = document.getElementById('storeBtnText');
    const spinner = document.getElementById('storeSpinner');
    btnText.textContent = 'Storing...';
    spinner.classList.add('show');
});

document.getElementById('retrieveForm').addEventListener('submit', function () {
    const btnText = document.getElementById('retrieveBtnText');
    const spinner = document.getElementById('retrieveSpinner');
    btnText.textContent = 'Retrieving...';
    spinner.classList.add('show');
});

document.getElementById('deleteForm').addEventListener('submit', function () {
    const btnText = document.getElementById('deleteBtnText');
    const spinner = document.getElementById('deleteSpinner');
    btnText.textContent = 'Deleting...';
    spinner.classList.add('show');
});