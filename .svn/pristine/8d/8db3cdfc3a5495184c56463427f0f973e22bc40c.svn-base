window.onload = function () {
    document.getElementById("enviar").onclick = function fun() {
        var usuario = "usuario desde web";
        var Url = "http://localhost:52766/api/Scheduler/UpdSchedule";
        var xhr = new XMLHttpRequest();
        var hrInicio = document.getElementById("TimeInic").value;
        var hrFin = document.getElementById("TimeFin").value;
        var json = {
            "HoraInicio": hrInicio,
            "HoraFin": hrFin,
            "usr": usuario
        };


        xhr.open('POST', Url, true);
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.send(JSON.stringify(json));

        xhr.onreadystatechange = processRequest;
        function processRequest(e) {
            if (xhr.readyState == 4 && xhr.status == 200) {
                // alert(xhr.responseText.headers.Host);
                var response1 = xhr.responseText;
                document.getElementById("test").innerHTML = "El nuevo horario fue registrado con éxito";

            }
            else {
                document.getElementById("test").innerHTML = "El nuevo horario no fue registrado";
            }
        }
    }
}