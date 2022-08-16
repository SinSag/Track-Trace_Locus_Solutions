function initialize(delLat, delLon, delName, colLat, colLon, colName, vehLat, vehLon, vehName) {
    var delivery = new google.maps.LatLng(delLat, delLon);
    var collect = new google.maps.LatLng(colLat, colLon);
    var vehicle = new google.maps.LatLng(vehLat, vehLon);
    var options = {
        zoom: 14,
        center: vehicle,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), options);
    var delMarker = new google.maps.Marker({
        position: delivery,
        title: delName,
        label: "Delivery location",
    });
    var colMarker = new google.maps.Marker({
        position: collect,
        title: colName,
        label: "Collect location",
    });
    var vehMarker = new google.maps.Marker({
        position: vehicle,
        title: vehName,
        label: "Driver",
    });
    delMarker.setMap(map);
    colMarker.setMap(map);
    vehMarker.setMap(map);
}

