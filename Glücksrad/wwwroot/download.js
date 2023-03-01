//https://stackoverflow.com/questions/52683706/how-can-one-generate-and-save-a-file-client-side-using-blazor
function saveAsFile(filename, content) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:text/plain;charset=utf-8," + content;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}