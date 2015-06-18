//Map functions
    function initialize() {

        var mapOptions = {
            center: new google.maps.LatLng(25.207997, 55.281819),
            zoom: 8
        };

        var map = new google.maps.Map(document.getElementById('map-canvas'),
          mapOptions);

        var drawingManager = new google.maps.drawing.DrawingManager({
            drawingMode: google.maps.drawing.OverlayType.MARKER,
            drawingControl: true,
            drawingControlOptions: {
                position: google.maps.ControlPosition.TOP_CENTER,
                drawingModes: [
                  google.maps.drawing.OverlayType.MARKER,
                  google.maps.drawing.OverlayType.CIRCLE,
                  google.maps.drawing.OverlayType.POLYGON,
                  google.maps.drawing.OverlayType.POLYLINE,
                  google.maps.drawing.OverlayType.RECTANGLE
                ]
            },
            markerOptions: {
                icon: 'images/beachflag.png'
            },
            circleOptions: {
                fillColor: '#ffff00',
                fillOpacity: 1,
                strokeWeight: 5,
                clickable: false,
                editable: true,
                zIndex: 1
            }
        });
        drawingManager.setMap(map);
        var coordinates;
        google.maps.event.addListener(drawingManager, 'polygoncomplete', function (polygon) {
            coordinates = (polygon.getPath().getArray());
            //console.log(JSON.stringify());
         

            console.log(coordinates);

            SendData(coordinates);

            bermudaTriangle = new google.maps.Polygon({
                paths: coordinates,
                strokeColor: '#FF0000',
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: '#FF0000',
                fillOpacity: 0.35
            });


        });

        google.maps.event.addListener(drawingManager, 'click', function (e) {
            
            alert(JSON.stringify(e.latLng));

        });

      

      

        google.maps.event.addListener(map, 'click', function (e) {
            if (google.maps.geometry.poly.containsLocation(e.latLng, bermudaTriangle)) {

                alert("in");

            } else {
                alert("out");
            }
        });
   

    }

google.maps.event.addDomListener(window, 'load', initialize);

function SendData(source) {
    


    var data = JSON.stringify(source);
    console.log(data);

    $.ajax({
        type: "POST",
        url: "http://localhost:13873/api/polygonapi",
        data: data,
        dataType: "json",
        contentType:'application/json',
        success: function (data) {
            alert(JSON.stringify(data));
        
        },
        error: function (error) {
            //jsonValue = jQuery.parseJSON(error.responseText);
            alert("Error");
        }
    });
}