﻿<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Gestor de Tareas</title>
</head>
<body>
    <h1>Gestor de Tareas</h1>
    <div id="menu">
        <button onclick="handleOption('1')">Agregar Tarea</button>
        <button onclick="handleOption('2')">Ver Tareas</button>
        <button onclick="handleOption('3')">Quitar Tarea</button>
        <button onclick="handleOption('4')">Marcar Tarea</button>
        <button onclick="handleOption('5')">Ver Ordenado</button>
        <button onclick="handleOption('6')">Salir</button>
    </div>
    <div id="output"></div>

    <script>
        function handleOption(option) {
            switch (option) {
                case '1':
                    agregarTarea();
                    break;
                case '2':
                    verTareas();
                    break;
                case '3':
                    quitarTarea();
                    break;
                case '4':
                    marcarTarea();
                    break;
                case '5':
                    verOrdenado();
                    break;
                case '6':
                    salir();
                    break;
                default:
                    alert('Opción no válida');
                    break;
            }
        }

        function agregarTarea() {
            document.getElementById('output').innerText = 'Agregar Tarea';
            // Lógica para agregar tarea
        }

        function verTareas() {
            document.getElementById('output').innerText = 'Ver Tareas';
            // Lógica para ver tareas
        }

        function quitarTarea() {
            document.getElementById('output').innerText = 'Quitar Tarea';
            // Lógica para quitar tarea
        }

        function marcarTarea() {
            document.getElementById('output').innerText = 'Marcar Tarea';
            // Lógica para marcar tarea
        }

        function verOrdenado() {
            document.getElementById('output').innerText = 'Ver Ordenado';
            // Lógica para ver tareas ordenadas
        }

        function salir() {
            document.getElementById('output').innerText = 'Salir';
            // Lógica para salir
        }
    </script>
</body>
</html>