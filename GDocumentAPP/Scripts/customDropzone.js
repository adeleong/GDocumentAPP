        Dropzone.options.dropzoneForm = {
         acceptedFiles: "image/*, application/pdf",
         maxFiles: 10,
         parallelUploads: 3,
         dictDefaultMessage: "Soltar los archivos o haga click aquí para cargar.",
          
            
         init: function () {
            
             this.on('sending', function (file, xhr, data) {
                 data.append('EmpleadoId', $("#EMPLEADO_ID").val());
             });

             this.on("maxfilesexceeded", function (data) {
                 var res = eval('(' + data.xhr.responseText + ')');
             });

             var thisDropzone = this;
               
             /*---------Obterner Documentos desde la busquedad Documento action ObternerDocumentos---------*/
             $("#btnSearch").click(function () {
                  getDocuments();            
              });
          
             $("#EMPLEADO_ID").change(function () {
                 getDocuments();
             });
             /* ----------------------------------------------Fin Obtener Documento-------------------------------------------------------*/

             this.on("addedfile", function (file) {

                 var indexarButton = Dropzone.createElement("<button type=\"button\" class=\"btn btn-outline btn-primary btn-sm glyphicon glyphicon-pushpin\" title=\"indexar\"> </button>");
                 var editButton = Dropzone.createElement("<button type=\"button\" class=\"btn btn-outline btn-warning btn-sm glyphicon glyphicon-pencil\" title=\"Editar\"> </button>");
                 var removeButton = Dropzone.createElement("<button type=\"button\" class=\"btn btn-outline btn-danger btn-sm glyphicon glyphicon-trash\" title=\"Eliminar\"> </button>");
                 var detalleButton = Dropzone.createElement("<button type=\"button\" class=\"btn btn-outline btn-info btn-sm glyphicon glyphicon-eye-open\" title=\"Detalle\"></button>");
                 var separator = Dropzone.createElement("<a> <a/>");
                 var separator2 = Dropzone.createElement("<a> <a/>");
                 var separator3 = Dropzone.createElement("<a> <a/>");
                 // Capture the Dropzone instance as closure.
                 var _this = this;

                 // Listen to the click event
                 removeButton.addEventListener("click", function (e) {
                     // Make sure the button click doesn't submit the form:

                     e.preventDefault();
                     e.stopPropagation();
                     var confirmAction = false;
                     var documentoId = file.id;
                     // Remove the file preview.

                     bootbox.confirm({
                         size: 'small',
                         message: "Eliminará el Documento " + file.name + "  del Expediente?",
                         callback: function (result) {
                             if (result) {
                                 window.location.href = "/Documento/Delete/" + documentoId;
                                 _this.removeFile(file);
                                        
                             }

                         }
                     })

                 });

                 detalleButton.addEventListener("click", function (e) {
                     window.location.href = "/Documento/Details/" + file.id;
                 });

                 editButton.addEventListener("click", function (e) {
                     window.location.href = "/Documento/Edit/" + file.id;
                 });

                 indexarButton.addEventListener("click", function (e) {
                     window.location.href = "/DocumentoIndexacion/Create";
                 });

                 file.previewElement.appendChild(indexarButton);
                 file.previewElement.appendChild(separator3);
                 file.previewElement.appendChild(detalleButton);
                 file.previewElement.appendChild(separator2);
                 file.previewElement.appendChild(editButton);
                 file.previewElement.appendChild(separator);
                 file.previewElement.appendChild(removeButton);
                                            
             });


             function getDocuments() {

                 var empleadoId = $("#EMPLEADO_ID").val();

                 var search = $("#search").val();

                 thisDropzone.removeAllFiles(true);

                 $.getJSON("/Documento/ObtenerDocumentos?empleadoId=" + empleadoId + "&search=" + search).done(function (data) {
                     if (data.Data != '') {

                         $.each(data.Data, function (index, item) {
                             //// Create the mock file:

                             var mockFile = {
                                 name: item.DocumentoNombre,
                                 size: item.DocumentoSize,
                                 id: item.DocumentoId
                             };

                             var thumbnail = $('.dropzone .dz-preview.dz-file-preview .dz-image:last');

                             // Call the default addedfile event handler
                             thisDropzone.emit("addedfile", mockFile);

                             // pathImage = item.attributeRuta;
                             // And optionally show the thumbnail of the file:
                             var rutaDocumento = item.DocumentoRuta + "/" + empleadoId + "/" + item.DocumentoNombre;
                             thisDropzone.emit("thumbnail", mockFile, rutaDocumento);

                             if (item.DocumentoNombre.substr(item.DocumentoNombre.lastIndexOf("."), item.DocumentoNombre.lenght) == ".pdf")
                                 thisDropzone.emit("thumbnail", mockFile, '/images/wallimages/pdf.png');

                             thisDropzone.files.push(mockFile);
                         });
                     } else {
                         thisDropzone.dictDefaultMessage = "No Hay Datos Para Mostrar.";
                     }

                 });
                 return false;

             }


         }


     };
