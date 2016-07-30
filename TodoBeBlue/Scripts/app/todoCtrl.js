var modulo = angular.module('TodoApp', []);

modulo.controller('TodoCtrl', ['$scope', '$http', '$filter', function ($scope, $http, $filter) {

    $scope.todos = [];
    var todos;    

    $scope.carregaTodos = function () {
        $http.get('api/todos').then(function (response) {
            todos = $scope.todos = response.data;

            $scope.$watch('todos', function () {
                $scope.todosRestantes = $filter('filter')(todos, { Feito: false }).length;
                $scope.todosFeitos = todos.length - $scope.todosRestantes;
                $scope.todosChecados = !$scope.todosRestantes;
            }, true);

            }, function () {

        });
    };

    $scope.adicionaTodo = function () {
        var novoTodo = {
            descricao: $scope.novoTodo.trim(),
            feito: false,
            prioridade: $scope.prioridadeTodo,
            CategoriaId: $scope.categoriaId
        };

        if (!novoTodo.descricao)
            return;

        $scope.salvando = true;

        $http.post('api/todos', novoTodo).then(function (response) {            
            $scope.novoTodo = "";
            $scope.carregaTodos();
        }, function () { });
    };

    $scope.editaTodo = function (todo) {        
        $http.put('api/todos', todo ).then(function (response) { }, function () { });
    }

    $scope.apagaTodo = function (id) {
        $http.delete('api/todos/' + id).then(function (response) {
            $scope.carregaTodos();
        }, function () { });

    };

    $scope.marcaTodos = function (marca) {
        $scope.todos.forEach(function (todo) {
            if (todo.Feito !== marca) {
                todo.Feito = marca;
                $scope.editaTodo(todo);
            }
        });
    };

    $scope.filtraStatus = function (status) {
        $scope.filtroStatus = status === 1 ? {} : status === 2 ? { Feito: false } : { Feito: true };
    };

    $scope.adicionaCategoria = function () {
        var novaCategoria = {
            Descricao: $scope.novaCategoria
        };

        if (!novaCategoria.Descricao)
            return;

        $http.post('api/categorias', novaCategoria).then(function (response) {
            $scope.carregaCategorias();
        }, function () { });
    };

    $scope.carregaCategorias = function () {
        $http.get('api/categorias').then(function (response) {
            $scope.categorias = response.data;
            $scope.novaCategoria = "";
        }, function () { });
    };

    $scope.carregaTodos();

    $scope.carregaCategorias();

}]);