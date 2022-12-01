<p align="center">
 <a href="#Descrição">Descrição</a> |
 <a href="#Diagramas">Diagramas</a> |
 <a href="#tecnologias">Tecnologias</a> |
 <a href="#autores">Autores</a>
</p>

# Jogo Futebol de Cabeção
<section id="Descrição">

## :soccer: Descrição:

O jogo futebol de cabeção consiste em 2 jogadores que controlam uma cabeça gigante e tentam fazer gol no gol dos seu respectivo adversário.  
Está sendo desenvolvido com o motor de jogo Unity e a linguagem de programação C#.
Utilizaremos o *Design Pattern* ***State*** para alterar o comportamento do jogador quando seu estado interno muda, de forma significativa e visível ao usuário, o ***Factory*** para construirmos objetos necessários, 
e o ***Command*** para encapsular solicitações como objetos para permitir a parametrização de diferentes solicitações, formar filas ou realizar um log.

</section>

<section id="Diagramas">
 
## 📈Diagramas C4
* ### [Diagrama de contexto]
Dois jogadores terão acesso a uma partida, que irá acontecer pelo serviço Unity, que conforme recebe comandos dos players, responde com as respectivas interações. Além disso, o jogo irá fazer trocas de informações a todo momento com o servidor externo do jogo, via HTTP e JSON.
 
<div align="center">
<img src="https://github.com/R0chR/POO_Game/blob/main/Documentation/Images/contextDiagram.svg" />
</div>

* ### [Diagrama de container]
Dois usuários irão acessar o jogo via Unity, que irá trocar informações com sistema de autenticação (Spring) para verificar a identidade dos jogadores. Durante a partida, comandos dos players serão recebidos pelo jogo, que a todo momento efetua troca de informações com o servidor em nuvem (AWS) e o sistema de controle de estatísticas (Spring) como, estados, pontuação, partida, entre outros. Todos os dados de autenticação e estatística serão lidos e escritos em um banco de dados externo (SQL) para armazenamento das informações dos jogadores, partidas, entre outros.   
  
<div align="center">
<img src="https://github.com/R0chR/POO_Game/blob/main/Documentation/Images/containerDiagram.svg" />
</div>

* ### [Diagrama de componentes - Jogo]
O ecossistema Unity terá seu comportamento definido por um container de três controladores. O primeiro, “Player Controller” diz respeito a todas as ações relacionadas ao personagem virtual do jogador, já o “Câmera Controller” sera responsável pelo posicionamento da câmera durante a execução do jogo, e o “Estatística Controller” irá manipular as informações de tempo, placar, entre outros. Esse contêiner de controladores irá enviar e solicitar dados ao contêiner de “Serviços Estatísticas”, que também registra tudo no banco de dados.
 
<div align="center">
<img src="https://github.com/R0chR/POO_Game/blob/main/Documentation/Images/gameComponentDiagram.svg" />
</div>

* ### [Diagrama de componentes - Serviço de autenticação]
 O Unity irá fazer uma requisição (JSON/HTTP) ao sistema de autenticação (Spring), responsável pelo controle de login e cadastro dos usuários, essa requisição sera detectada pelo controlador de autenticação, caso possua endpoint de autenticação mapeadas, ou pelo controlador de cadastro, caso possua endpoint de cadastro mapeadas.

 No caso de autenticação, a requisição sera transmitida para o processador de requisição de autenticação, que irá enviar os objetos ao serviço de autenticação que repassa a operação ao repositório de usuário, para leitura e escrita no banco de dados (SQL) das informações do usuário. O mesmo processo se repete em caso de cadastro, porém para processadores e serviços da respectiva requisição. 

<div align="center">
<img src="https://github.com/R0chR/POO_Game/blob/main/Documentation/Images/authServiceComponentDiagram.svg" />
</div>

## Diagramas Design Patterns 

### Diagrama do Padrão Command
O Pattern Command sera responsável por ler os dados brutos enviados pelo jogador, como as teclas pressionadas por exemplo. Cada comando sera captado e traduzido para uma ação significativa no jogo, como movimentação do personagem e interações com a bola e o gol.
Neste caso, o Client (Jogo) terá um Receiver, uma interface com todos os métodos que dizem respeito aos objetos do jogo, tendo em sua derivação os próprios objetos (Jogador, Bola e Gol), que compõem o grupo dos Concrete Receivers. O Field (Campo) sera um Invoker para a interface de comando, com os respectivos comandos possíveis de acordo com a entrada do player, como chutar a bola ou movimentar o personagem, essas ações são caracterizadas como comandos concretos.
<img src="Documentation/Images/DiagramaDeClassesUML.png" />

### Diagrama do Padrão State
O Pattern State sera utilizado para controlar os diferentes estados dos players durante a partida, em que cada classe representara um estado.
Todos os estados possíveis terão uma classe, com todos os seus respectivos comportamentos específicos extraídos para tal. Para eliminar a necessidade de implementar os comportamentos por conta própria, o objeto original StatefulPlayer, nosso Context, armazena uma referência a um dos objetos de estado que representa seu estado atual e delega o trabalho. A interface State sera responsável pelo armazenamento de todos os estados possíveis, e a classe abstrata terá como alvo o Context, no caso, o jogador. Cada classe abaixo da abstrata representa um possível estado de jogador durante a partida, Normal, Lento, Rápido, Gigante e Congelado, com os respectivos métodos para o pleno funcionamento.
<img src="Documentation/Images/DiagramaDeClassesState.jpg">
</section>

<section id="tecnologias">
</section>

## :desktop_computer: Tecnologias utilizadas

- Unity:
- C#
- Java
- SpringBoot
- PlantUML



<section id="autores">
</section>  

## :family_man_man_boy: Autores

- Gabriel Augusto - CP3020207
- Lucas Rocha - CP3020215
- William Gabriel - CP3020022
