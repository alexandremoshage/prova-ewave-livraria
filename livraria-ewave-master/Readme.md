# livraria

Este projeto visa controlar a cadastro de livros, cadastro de usuários e o cadastro de entidades de ensino,
Foram implementado as rotinas de Emprestimo, devolução e reserva de livros

Foi implementado usando DDD, C#, Entity core e foi implementado os métodos de teste para as entidades

O back-end é uma API, para acessar ela basta inciar o projeto e entrar no link http://localhost:60927/swagger/index.html

O Front End foi feito usando apenas Jquery e Boostrap


## BD e configuração
Foi ultilizado o SQL SERVER, como dito acima utilizando o Entity core para acesso-lo, 
Segue o script com os dados e as tabelas do banco de dados no caminho script/banco.sql
Não se esqueça de alterar a string de conexão no appsettings.json
