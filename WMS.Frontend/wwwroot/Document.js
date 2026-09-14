// async function downloadFile(fileName, streamRef) {
//     const response = await fetch(streamRef);
//     const blob = await response.blob();
//     const url = window.URL.createObjectURL(blob);
//     const a = document.createElement('a');
//     a.style.display = 'none';
//     a.href = url;
//     a.download = fileName;
//     document.body.appendChild(a);
//     a.click();
//     window.URL.revokeObjectURL(url);
// }

// async function downloadFile(fileName, streamRef) {
//     const url = streamRef.url; // This should retrieve the Blob URL directly
//     const a = document.createElement('a');
//     a.style.display = 'none';
//     a.href = url;
//     a.download = fileName;
//     document.body.appendChild(a);
//     a.click();
//     document.body.removeChild(a);
// }

// async function downloadFile(fileName, streamRef) {
//     try {
//         const url = streamRef.url; // Ensure this retrieves the Blob URL correctly
//         const a = document.createElement('a');
//         a.style.display = 'none';
//         a.href = url;
//         a.download = fileName;
//         document.body.appendChild(a);
//         a.click();
//         document.body.removeChild(a);
//         // Optional: Show success message or handle post-download actions
//     } catch (error) {
//         console.error('Error during file download:', error);
//     }
// }

// async function downloadFile(fileName, streamRef) {
//     try {
//         // Create a URL from the stream reference directly
//         const url = streamRef.url; // Access the URL property of the streamRef
//         const a = document.createElement('a');
//         a.style.display = 'none';
//         a.href = url;
//         a.download = fileName;
//         document.body.appendChild(a);
//         a.click();
//         document.body.removeChild(a);
//         window.URL.revokeObjectURL(url); // Clean up the URL
//     } catch (error) {
//         console.error('Error during file download:', error);
//     }
// }

function downloadFile(fileName, base64Data) {
    const link = document.createElement('a');
    link.href = 'data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,' + base64Data;
    link.download = fileName;
    link.click();
}