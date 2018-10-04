# CopaFilmes
Realiza Competição de Filmes


Para solução do problema proposto, criei um projeto MVC.

 - Primeiro Criei uma classe Filme com todas as propriedades necessárias de acordo com o retorno da API;

 - Criei um método no Controller Home chamado GetALLFilmes para consumir a API e capturar a listagem com os 16 filmes
 
 - Ordenei o resultado por ordem alfabética para melhor visualização e criei uma view para exibição dos 16 filmes.
Nesta view Index.cshtm, utilizei HtmlHelper para listar os Itens em tela, através do @model.
Adicionei componentes CheckBox para cada filme e criei uma função QteSelecionados, sendo chamado no evento onclick, para contar a quantidade 
de registros selecionados e exibição em tela.
	As tags "checkbox" foram criadas numa tag "Form" e adicionei uma função no evento "onSubmit" do form, para não permitir a competição
se o número de filmes selecionados for diferente de 8. Se quantidade selecionados for igual 8, é iniciada a competição, caso contrário, é enviado um alert com uma mensagem informativa.

 - A competição se inicia, ao clicar no botão "Gerar Meu campeonato", onde é passado para Controller um array de strings com os "Id's" dos titulos selecionados.
	A ActionResult ExibeVencedor é acionada e nela, consulto novamente os 16 filmes passados pela API e filtro os filmes selecionados de acordo com o array recebido do post do formulário.
De posse dos 8 filmes, faço uma ordenação por ordem alfabética com base na propriedade Titulo.
Em seguida chamo um método ComparaTitulo responsável por gerar o Vencedor e vice.

 - Como proposta de solução, o método ComparaTitulo  contém 3 Listas de Filmes: grupo1, grupo2 e grupo3.
No grupo1, inseri os 4 primeiros filmes(0,1,2,3) e no grupo 2, os outros 4 filmes (4,5,6,7).
Realizei a disputa entre o grupo1 e grupo2, gerando o grupo3 com o resultado da disputa.

 - À partir do grupo3, realizei a disputa da primeira posição com a segunda, e a terceira com a quarta gerando uma lista de Vencedores com 2 filmes.
 
 - Ordenei a lista de vencedores por Nota e assim obtive o Vencedor e o vice. Essa lista é retornada para a view para exibição.





