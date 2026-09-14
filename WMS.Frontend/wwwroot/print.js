function printComponent(componentSelector) {
    var elementToPrint = document.querySelector(componentSelector);
    if (elementToPrint) {
      var printWindow = window.open('', '_blank');
      printWindow.document.open();
      printWindow.document.write('<!DOCTYPE html><html lang="en"><head><meta charset="utf-8" /><meta name="viewport" content="width=device-width, initial-scale=1.0" /><link rel="stylesheet" href="app.css" /><link rel="stylesheet" href="WMS.Frontend.styles.css" /><link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"><link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css"><link href="_content/Blazor.Bootstrap/blazor.bootstrap.css" rel="stylesheet" /><body onafterprint="window.close()">');
      printWindow.document.write(elementToPrint.innerHTML);
      printWindow.document.write('<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script><script src="_framework/blazor.web.js"></script><script src="_content/Blazor.Bootstrap/blazor.bootstrap.js"></script><script src="print.js"></script></body></html>');
      printWindow.document.close();
      printWindow.print();
      printWindow.focus();
    }
}