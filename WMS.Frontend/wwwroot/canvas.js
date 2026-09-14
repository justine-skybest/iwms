let canvas;

function InitializeCanvas(canvasName, backgroundImage) {    
    canvas = new fabric.Canvas(canvasName, { isDrawingMode: false });    
    fabric.Image.fromURL(backgroundImage, function (img) {
        let canvasWidth = img.width * 0.5;
        let canvasHeight = img.height * 0.5;

        // Check if either dimension is smaller than 300px
        if (img.width < 300 || img.height < 300) {
            canvasWidth = img.width;
            canvasHeight = img.height;
        } else {
            // Continuously reduce dimensions until both are <= 1000px
            while (canvasWidth > 1000 || canvasHeight > 1000) {
                canvasWidth *= 0.95;
                canvasHeight *= 0.95;
            }
        }

        // Set the canvas dimensions
        canvas.setWidth(canvasWidth);
        canvas.setHeight(canvasHeight);

        // Set the image properties to fit the canvas
        img.set({
            left: 0,
            top: 0,
            scaleX: canvasWidth / img.width,
            scaleY: canvasHeight / img.height,
            selectable: false // Make it non-selectable if it's a background
        });

        // Add the image to the canvas
        canvas.setBackgroundImage(img, canvas.renderAll.bind(canvas));
        
        $('#AddBox').on('click', function (e) {
            e.preventDefault();
            const minWidth = canvasWidth * 0.2;
            const minHeight = canvasHeight * 0.2;

            // Create the rectangle with the calculated minimum size
            const rectangle = new fabric.Rect({
                left: 10,
                top: 10,
                width: minWidth,
                height: minHeight,
                fill: 'rgba(0, 0, 0, 0.5)',
                stroke: 'black',
                strokeWidth: 5,
                rx: 5, // Round corners
                ry: 5
            });

            // Add the rectangle to the canvas
            canvas.add(rectangle);

            // Handle resizing for the rectangle to avoid pixelation
            rectangle.on('scaling', function () {
                const scaleX = rectangle.scaleX;
                const scaleY = rectangle.scaleY;

                // Maintain aspect ratio (optional)
                const aspectRatio = rectangle.width / rectangle.height;
                rectangle.set({
                    width: rectangle.width * scaleX,
                    height: rectangle.width * scaleY / aspectRatio,
                    scaleX: 1,
                    scaleY: 1
                });
                canvas.renderAll();
            });
        });

        // // Calculate minimum size for the rectangle (20% of the canvas size)
        // const minWidth = canvasWidth * 0.2;
        // const minHeight = canvasHeight * 0.2;

        // // Create the rectangle with the calculated minimum size
        // const rectangle = new fabric.Rect({
        //     left: 10,
        //     top: 10,
        //     width: minWidth,
        //     height: minHeight,
        //     fill: 'rgba(0, 0, 0, 0.5)',
        //     stroke: 'black',
        //     strokeWidth: 5,
        //     rx: 5, // Round corners
        //     ry: 5
        // });

        // // Add the rectangle to the canvas
        // canvas.add(rectangle);

        // // Handle resizing for the rectangle to avoid pixelation
        // rectangle.on('scaling', function () {
        //     const scaleX = rectangle.scaleX;
        //     const scaleY = rectangle.scaleY;

        //     // Maintain aspect ratio (optional)
        //     const aspectRatio = rectangle.width / rectangle.height;
        //     rectangle.set({
        //         width: rectangle.width * scaleX,
        //         height: rectangle.width * scaleY / aspectRatio,
        //         scaleX: 1,
        //         scaleY: 1
        //     });
        //     canvas.renderAll();
        // });
    });

    $('#AddText').on('click', function (e) {
        e.preventDefault();
        const text = new fabric.IText('Text', {
            left: 40,
            top: 40,
            objecttype: 'text',
            fontFamily: 'Arial Black',
            fill: 'white',
            stroke: 'black',
            strokeWidth: 1,
            fontSize: 20 // Set a default font size
        });

        canvas.add(text);
    });    

    $('#RemoveObject').on('click', function (e) {
        canvas.remove(canvas.getActiveObject());
    });
    
    canvas.on('selection:created', function () {
        $('#RemoveObject').prop('disabled', '');
    });
    canvas.on('selection:cleared', function () {
        $('#RemoveObject').prop('disabled', 'disabled');
    });
}

function getCanvasObjects(canvasName) {
    if (!canvas) {
        console.error("Canvas not initialized.");
        return [];
    }
    let objects = canvas.getObjects();  // Get all objects on the canvas
    return objects.map(obj => {
        return {
            type: obj.type,
            left: obj.left,
            top: obj.top,
            width: obj.width * obj.scaleX, // Get actual width, considering scaling
            height: obj.height * obj.scaleY, // Get actual height, considering scaling
            text: obj.text || '', // Default empty text if not a text object
            fill: obj.fill,
            stroke: obj.stroke,
            strokeWidth: obj.strokeWidth,
            fontSize: obj.fontSize || 20, // Default font size if not set        
            scaleX: obj.scaleX,
            scaleY: obj.scaleY,
            angle: obj.angle
        };
    });
}

// Function to render RackFloorMapObject data on Canvas
function renderObjectsOnCanvas(canvasName, backgroundImage, rackFloorMapObjects) 
{    
    canvas = new fabric.Canvas(canvasName, { isDrawingMode: false });
    canvas.clear();

    fabric.Image.fromURL(backgroundImage, function (img) {
        let canvasWidth = img.width * 0.5;
        let canvasHeight = img.height * 0.5;

        // Check if either dimension is smaller than 300px
        if (img.width < 300 || img.height < 300) {
            canvasWidth = img.width;
            canvasHeight = img.height;
        } else {
            // Continuously reduce dimensions until both are <= 1000px
            while (canvasWidth > 1000 || canvasHeight > 1000) {
                canvasWidth *= 0.95;
                canvasHeight *= 0.95;
            }
        }

        // Set the canvas dimensions
        canvas.setWidth(canvasWidth);
        canvas.setHeight(canvasHeight);

        // Set the image properties to fit the canvas
        img.set({
            left: 0,
            top: 0,
            scaleX: canvasWidth / img.width,
            scaleY: canvasHeight / img.height,
            selectable: false // Make it non-selectable if it's a background
        });

        // Add the image to the canvas
        canvas.setBackgroundImage(img, canvas.renderAll.bind(canvas));

        $('#AddBox').on('click', function (e) {
            e.preventDefault();
            const minWidth = canvasWidth * 0.2;
            const minHeight = canvasHeight * 0.2;
    
            // Create the rectangle with the calculated minimum size
            const rectangle = new fabric.Rect({
                left: 10,
                top: 10,
                width: minWidth,
                height: minHeight,
                fill: 'rgba(0, 0, 0, 0.5)',
                stroke: 'black',
                strokeWidth: 5,
                rx: 5, // Round corners
                ry: 5
            });
    
            // Add the rectangle to the canvas
            canvas.add(rectangle);
    
            // Handle resizing for the rectangle to avoid pixelation
            rectangle.on('scaling', function () {
                const scaleX = rectangle.scaleX;
                const scaleY = rectangle.scaleY;
    
                // Maintain aspect ratio (optional)
                const aspectRatio = rectangle.width / rectangle.height;
                rectangle.set({
                    width: rectangle.width * scaleX,
                    height: rectangle.width * scaleY / aspectRatio,
                    scaleX: 1,
                    scaleY: 1
                });
                canvas.renderAll();
            });
        });
    });

    
     
    rackFloorMapObjects.forEach(rfo => {
        if (rfo.type == "rect") {
            const rectangle = new fabric.Rect({
                left: rfo.left,
                top: rfo.top,
                width: rfo.width,
                height: rfo.height,
                fill: rfo.fill || 'gray', // Default to gray if no fill specified
                stroke: rfo.stroke || 'black', // Default to black if no stroke specified
                strokeWidth: rfo.strokeWidth || 1, // Default stroke width
                rx: 5, // Optional: Round corners
                ry: 5 // Optional: Round corners
            });
        
            // Add the rectangle to the canvas
            canvas.add(rectangle);
        }

        if (rfo.type == "i-text") {
            const text = new fabric.IText(rfo.text || 'Text', {
                left: rfo.left,
                top: rfo.top,
                objecttype: 'text',
                fontFamily: 'Arial Black',
                fill: rfo.fill || 'white', // Default fill
                stroke: rfo.stroke || 'black', // Default stroke
                strokeWidth: rfo.strokeWidth || 1,
                fontSize: rfo.fontSize || 20, // Default font size
                scaleX: rfo.scaleX,
                scaleY: rfo.scaleY,
                angle: rfo.angle
            });

            // Add the text object to the canvas
            canvas.add(text);
        }
    });    
    
    canvas.renderAll();   

    $('#AddText').on('click', function (e) {
        e.preventDefault();
        const text = new fabric.IText('Text', {
            left: 40,
            top: 40,
            objecttype: 'text',
            fontFamily: 'Arial Black',
            fill: 'white',
            stroke: 'black',
            strokeWidth: 1,
            fontSize: 20 // Set a default font size
        });

        canvas.add(text);
    });

    $('#RemoveObject').on('click', function (e) {
        canvas.remove(canvas.getActiveObject());
    });
    
    canvas.on('selection:created', function () {
        $('#RemoveObject').prop('disabled', '');
    });
    canvas.on('selection:cleared', function () {
        $('#RemoveObject').prop('disabled', 'disabled');
    });
}

function InitializeWarehouseCanvas(canvasName, backgroundImage, rackFloorMapObjects, modalId)
{
    canvas = new fabric.Canvas(canvasName, { isDrawingMode: false });
    canvas.clear();

    fabric.Image.fromURL(backgroundImage, function (img) {
        let canvasWidth = img.width * 0.5;
        let canvasHeight = img.height * 0.5;

        // Check if either dimension is smaller than 300px
        if (img.width < 300 || img.height < 300) {
            canvasWidth = img.width;
            canvasHeight = img.height;
        } else {
            // Continuously reduce dimensions until both are <= 1000px
            while (canvasWidth > 1000 || canvasHeight > 1000) {
                canvasWidth *= 0.95;
                canvasHeight *= 0.95;
            }
        }

        // Set the canvas dimensions
        canvas.setWidth(canvasWidth);
        canvas.setHeight(canvasHeight);

        // Set the image properties to fit the canvas
        img.set({
            left: 0,
            top: 0,
            scaleX: canvasWidth / img.width,
            scaleY: canvasHeight / img.height,
            selectable: false // Make it non-selectable if it's a background
        });

        // Add the image to the canvas
        canvas.setBackgroundImage(img, canvas.renderAll.bind(canvas));
        // Adjust the modal size after the canvas is set
        adjustModalSize(modalId, canvasWidth + 40, canvasHeight);
    });

    
     
    rackFloorMapObjects.forEach(rfo => {
        if (rfo.type == "rect") {
            const rectangle = new fabric.Rect({
                left: rfo.left,
                top: rfo.top,
                width: rfo.width,
                height: rfo.height,
                fill: rfo.fill || 'gray', // Default to gray if no fill specified
                stroke: rfo.stroke || 'black', // Default to black if no stroke specified
                strokeWidth: rfo.strokeWidth || 1, // Default stroke width
                rx: 5, // Optional: Round corners
                ry: 5, // Optional: Round corners
                selectable : false
            });
            
            
            // Add the rectangle to the canvas
            canvas.add(rectangle);
            rectangle.sendToBack();
        }

        if (rfo.type == "i-text") {
            const text = new fabric.IText(rfo.text || 'Text', {
                left: rfo.left,
                top: rfo.top,
                objecttype: 'text',
                fontFamily: 'Arial Black',
                fill: rfo.fill || 'white', // Default fill
                stroke: rfo.stroke || 'black', // Default stroke
                strokeWidth: rfo.strokeWidth || 1,
                fontSize: rfo.fontSize || 20, // Default font size
                scaleX: rfo.scaleX,
                scaleY: rfo.scaleY,
                angle: rfo.angle,
                selectable : false
            });

            // Add the text object to the canvas
            canvas.add(text);
            text.bringToFront();
        }
    });    
    
    canvas.renderAll();   
}

// Function to adjust the modal size based on canvas size
function adjustModalSize(modalId, canvasWidth, canvasHeight) {
    // Select the modal by its ID
    var modal = $('#' + modalId);
    var modalDialog = modal.find('.modal-dialog');
    var modalBody = modal.find('.modal-body');

    // Adjust the modal size based on the canvas size
    modalDialog.css({
        'max-width': canvasWidth + 'px',
        'max-height': canvasHeight + 'px',
        'min-width': '300px'
    });

    // Check if the canvas size exceeds the modal size and make the body scrollable if necessary
    if (canvasWidth > modalDialog.width() || canvasHeight > modalDialog.height()) {
        modalBody.css({
            'overflow': 'auto', // Enable scroll
        });
    } else {
        modalBody.css({
            'overflow': 'hidden' // No scroll needed if the content fits
        });
    }
}
