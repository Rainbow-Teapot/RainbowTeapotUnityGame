# Braking Down
**Idea General:**

<p align="center">
     <img src="Imagenes_readme/tabla.PNG">
</p>

**Contexto Hist�rico:**
<p>Europa, siglo XXI. Concretamente, el a�o 2017. Lucho naci� en el seno de una familia de clase media europea. Vive con sus padres y su hermano mayor en un chal� a las afueras de la capital. La situaci�n en su pa�s es bastante buena. El gobierno ha puesto mucho empe�o en la clase media, lo que hizo que familias como las de Lucho pudieran tener un nivel de vida mucho mejor que el que ten�an hace 10 a�os.</p>

**Descripci�n breve del juego:**

<p>En un peque�o pueblo de Wisconsin, Lucho, un peque�o ni�o de un a�o ha decidido que es hora de jugar. Es invierno, por lo que hace mucho fr�o y no puede disfrutar de la compa��a de sus perros en la calle. Tiene que encontrar una nueva forma de entretenimiento�</p>
<p>Buscando por su habitaci�n, ha encontrado un mont�n de juguetes con ruedas y se le ha ocurrido una idea genial: �Van a hacer una carrera, pero ser� el �ltimo el que gane, los dem�s ser�n devorados�. Como circuito de competici�n ha elegido las paredes de su habitaci�n, �ser� una carrera en ca�da libre!</p>
<p>Lucho tiene mucha imaginaci�n, as� que los juguetes compiten en una inmensidad de escenarios diferentes de lo m�s dispares, desde un mundo de chucher�as, hasta el sitio donde podr�an ocurrir sus peores pesadillas, pero sin perder nunca el aspecto infantil.</p>
<p>Lo que tendr�n que intentar los juguetes es chocarse con todos los elementos que puedan e ir por las superficies que m�s le retrasen, pues no quieren ser aquellos que acaben en la boca de ese travieso beb� llenos de babas y de restos de gusanitos.</p>

**Prueba nuestro juego aqu�:**

<p>Github-pages: <strong>https://rainbow-teapot.github.io/RainbowTeapotGame/</strong> </p>


**Mec�nicas del juego:**
<p>El jugador deber� elegir el juguete que querr� salvar de las babas del beb�. Cuando comience la partida y todos los jugadores est�n listos, habr� que hacer todo lo posible por quedar en �ltima posici�n y salvarse de Lucho.</p>
<p>Para ello, tendremos que darnos de golpes con todos los obst�culos que podamos para reducir nuestra velocidad y hacer que los dem�s jugadores nos adelanten. Solo as� podremos quedar en �ltima posici�n y ganar la partida, v�ase la moreleja. Tambi�n existir�n diversos eventos dentro de cada mapa que influir�n en la velocidad y direcci�n del juguete que manejemos.</p>
<p>Por si esto no fuera suficiente, existir�n diferentes objetos que los jugadores podr�n recoger para cambiar las tornas en la posici�n dentro de carrera.</p>
<p></p>

**Progesi�n del Juego:**

<p align="center">
     <img src="Imagenes_readme/Diagrama_De_Flujo.png">
</p>

**Inicio de Juego:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_Iniciar.png">
</p>

<p>La primera pantalla de nuestro juego. En esta pantalla aparecer� el t�tulo del juego con una peque�a animaci�n, el nombre de nuestro jugador y un bot�n que tiene escrito Login.</p>
<p>Para cambiar el nombre simplemente tendremos que pulsar o clicar sobre el propio texto, y podremos poner el nombre que tendr� nuestro jugador durante el resto del tiempo que est� jugando al juego. Una vez tengamos nuestro nombre, pulsaremos el bot�n de Login, que nos llevar� al men� principal.</p>




**Men� principal:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_menu_ppal.png">
</p>

<p>Nos encontraremos con el mismo titulo del juego que en la pantalla anterior. A parte tendremos dos botones, uno para cada modo de juego. El bot�n de arriba nos llevar� al modo de entrenamiento, mientras que el de abajo, al del modo multijugador.</p>
<p>Adicionalmente, tendremos dos botones, debajo de los otros dos ya mencionados. Estos dos botones corresponden a los ajustes de juego y a los cr�ditos. El de la izquierda, con una �i�, corresponde al apartado de cr�ditos, mientras que el de la derecha, en azul con una rueda, nos llevar� al men� de opciones.</p>

**Cr�ditos:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_creditos.png">
</p>

<p>A modo de informaci�n adicional, se podr�n ver los nombres de los desarrolladores del juego, junto con el estudio. Contendr� informaci�n acerca de la red social de �ste, por si se quiere hacer alg�n tipo de contacto con el propio estudio, o para seguir de cerca el desarrollo del estudio. Toda esta informaci�n estar� recogida dentro de un cuadradito de color diferente al del fondo.</p>
<p>Al igual que en la pantalla del men� de opciones, en la parte superior izquierda de la pantalla, tenemos un bot�n con forma de flecha que nos har� volver al men� principal.</p>


**Men� de Opciones:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_opciones.png">
</p>
<p>En esta pantalla podremos cambiar los ajustes necesarios para que la experiencia de juego sea lo m�s personalizada posible, dentro de unos est�ndares. Nos aparecer� un cuadrado en color verde, distinto al color del fondo, donde se recogen todas las configuraciones que podemos hacer del juego de manera general.</p>
<p>Podemos configurar el sonido del juego general, referido a la m�sica y a los efectos; teniendo un bot�n diferente para ambos tipos de sonido. Estos botones simplemente apagan o encienden la m�sica y los efectos de sonido, respectivamente.</p>
<p>Adem�s, tenemos un bot�n que nos permite cambiar de idioma, entre ingl�s y espa�ol. Cuando aparezca la bandera de un pa�s, indicar� que para cambiar al idioma de ese pa�s deberemos de clicar sobre la bandera.</p>
<p>Por �ltimo, en la parte superior izquierda de la pantalla, tenemos un bot�n con forma de flecha que nos har� volver al men� principal.</p>

**Selecci�n de Personaje:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game.png">
</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game.png">
</p>

<p>Tanto si le damos al bot�n de Entrenamiento o al de Multijugador, nos llevar� a la pantalla de selecci�n del personaje, que se compondr� de dos pantallas:</p>
<p>Primero nos aparecer� un cuadradito flotando donde se podr� ver la totalidad de los personajes que tiene el jugador en cuesti�n. Aparecer�n todos seguidos unos de otros, formando una especie de cuadr�cula. En cada uno de los cuadraditos aparecer� una imagen que representar� a cada uno de los personajes jugables.</p>
<p>Cuando seleccionemos el personaje que queremos usar, nos llevar� a la segunda pantalla, donde podremos ver como es el personaje en 3D con su animaci�n propia de idle. En esta pantalla tambi�n podemos girar el juguete 360 grados para poder verlo desde la perspectiva que queramos. Asimismo, podremos cambiar nuestro personaje con las flechas que aparecen a los lados del modelo. Cada vez que cambiemos de personaje, sonar� el efecto de sonido propio que tiene, porque cada uno tiene el suyo.</p>
<p>En la parte superior izquierda de la pantalla, tendremos el bot�n con la flecha, que nos permitir� volver a la pantalla anterior de la selecci�n de personajes. Para volver al men� principal deberemos volver a clicar sobre la flecha en esta segunda pantalla</p>
<p>Cuando hayamos decidido nuestro personaje, le daremos al bot�n que aparece en la parte de debajo de la pantalla, para unirnos a una sala si hay alguna con hueco, o crearemos una sala nueva en caso contrario.</p>

**Sala de espera(pre-partida):**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game.png">
</p>
<p>Esta sala nos da la informaci�n acerca de los jugadores que hay en la sala, nos pone el nombre del jugador junto con una imagen con el juguete que ha escogido. En la parte derecha de la pantalla, al lado de cada jugador, aparecer� un circulo que nos dir� si el jugador est� preparado o no para jugar la partida.</p>
<p>Cuando intentamos unirnos a una sala, o incluso crearla, nos sale una pantalla para avisar al jugador que est� intentando unirse, para que se eviten pensamientos de que el juego se ha quedado bloqueado.</p>
<p>En la parte de debajo de la pantalla, tendremos un bot�n, que nos permitir� salir de la sala en la que estamos. De manera excepcional, el jugador que haya creado la sala podr� darle al bot�n de jugar la partida, pero solo cuando todos los jugadores que hay en la sala hayan aceptado empezar la partida.</p>
<p></p>


**Partida:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game.png">
</p>

<p>Al comenzar una partida, ir�n apareciendo todos los jugadores de la sala de uno en uno en la pantalla, como si llegasen y se parasen en la l�nea de salida para jugar. Podemos observar que en la parte de arriba de la pantalla tenemos dos cosas: A la izquierda tenemos el hueco donde aparecer�n los power-downs una vez que cojamos una caja de power-downs.</p>
<p>Tambi�n en la parte de arriba, justo debajo de la cajita de los power-down, tenemos una ruedecita de ajustes, que nos llevar� al men� de ajustes in game. Volviendo a la partida, en la parte de la derecha de la pantalla, siguiendo en la vista de arriba, tenemos un n�mero que nos indica la posici�n en la que estamos respecto de los dem�s jugadores, pero no el que va primero o �ltimo en el nivel, sino en la carrera.</p>
<p>El juego se desarrolla en el escenario que se ve, pudiendo mover el personaje por toda la zona que tiene el jugador a la vista. Los bordes est�n decorados con objetos tem�ticos, junto con el resto de los objetos interactivos dentro del escenario.</p>


**Men� de Opciones In-Game:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game_opciones.png">
</p>

<p>A este men� solo podremos acceder en el caso de que estemos jugando una partida. Las opciones que podemos configurar aqu� son las mismas que en el men� de opciones que hay en el men� principal, exceptuando el cambio de idioma. </p>
<p>Sin embargo, al ser una partida multijugador, aunque estemos en el men�, la partida no se parar� puesto que molestar�a al resto de jugadores. A trav�s de esta pantalla, podemos salirnos de la partida en cualquier momento para volver al men� principal si pulsamos el bot�n que tenemos debajo de los ajustes de sonido. </p>
<p>Para volver a la partida, tendremos que pulsar el bot�n que est� encima del men�, que aparece como una flecha, al igual que en otras pantallas anteriores. </p>


**Fin del Juego:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>A esta pantalla solo podemos acceder una vez que haya acabado una partida multijugador. En la propia pantalla aparecer� la posici�n con la que ha quedado tu personaje dentro de la ultima carrera, y, adem�s, un bot�n para volver al men� principal. </p>

**Personajes:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	La vaca paca: Juguete que lleva mucho tiempo con Lucho, al cual tiene mucho aprecio. Es una vaquita blanca con manchas negras, y unas paletas con ruedas atadas a las patas.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Patinete Molinete: Uno de los dos patines que regalaron a Lucho con 6 meses. Como de momento es muy peque�o para poder usarlos, los utiliza para jugar con ellos como si fueran coches grandes. Consiste en un pat�n con est�tica retro de los a�os 80 con dos filas de dos ruedas, a modo de cochecito.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	V�ter Manolo: Un divertido v�ter de juguete que echa agua cuando le das a la palanca de tirar de la cadena. El padre de Lucho le hizo una peque�a puesta a punto, y le puso cuatro ruedas a los lados para que Lucho pudiera usarlo como un coche que echa agua, ya que siempre a Lucho le ha gustado mucho este tipo de juguetes.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Tel�fono Loco: Un tel�fono de estilo retro de juguete, con sus botones con los n�meros del 1 al 9, cada uno con un sonido diferente, si lo pulsamos. Tambi�n tiene el propio mango del tel�fono, que reproduce una melod�a si se toca la combinaci�n correcta de n�meros. Al principio era blanco, pero Lucho le pego unas pegatinas en forma de estrella de colores, para que tuviese m�s estilo. Aunque �l no sabe ni que es el estilo ni nada.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Narangina Carolina: Un juguetito muy curioso que fue regalado a Lucho el mismo d�a que los patines. Se trata de una media naranja de pl�stico con dos ruedas, una a cada lado, dos ojitos en la parte superior de la media naranja, y una cuerdecita con una arandela, en forma de hoja, tambi�n de pl�stico, la cual hace que la naranjita se mueva cuando tiramos de esta anilla. Este juguetito tiene una curiosidad y es que cuando se compr� ven�a con un intenso olor a caramelo de naranja, lo que hizo que Lucho quisiera com�rselo en un par de ocasiones. Afortunadamente, ese olor se fue perdiendo con el tiempo, y ahora Lucho prefiere jugar con el que chuparlo.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Lucho: Nuestro protagonista Es el creador y todopoderoso jefe de este juego. Qui�n sabe que rondar� por su cabeza para que sea capaz de imaginarse tantas cosas, como las historias de cada uno de sus juguetes, y como van a interactuar unos con otros y con el entorno. Lamentablemente, no es un personaje jugable, pero tendr� controlado en todo momento la situaci�n de sus juguetes en la partida.</p>
<p>Lucho es el segundo hijo de una familia de clase media europea. Tiene mucho inter�s por todo lo que tiene ruedecitas y se mueve, seguramente tendr� mucho futuro en alg�n trabajo que tenga que ver con veh�culos con ruedas. Es un ni�o algo rebelde, pero por lo general se porta bien con sus padres y su hermano mayor, no es demasiado trasto. Algo dentro de los baremos normales de un ni�o de 2 a�os.</p>
<p></p>

**Controles:**

<p>El juguete se mover� de manera autom�tica hacia abajo, nosotros solo tendremos que controlar la direcci�n de �ste durante el recorrido.</p>
<p>En caso de jugar en un ordenador, moveremos nuestro juguete con el rat�n de izquierda a derecha. Si dejamos de pulsar el bot�n del rat�n, el personaje se quedar� en la posici�n en la cual se haya dejado de pulsar dicho bot�n.</p>
<p>Si jugamos desde un dispositivo m�vil, tendremos que pulsar la pantalla, y mantener el dedo para que el personaje pueda moverse. Al igual que en un ordenador con el rat�n, si dejamos el pulsar la pantalla, el juguete se quedar� en esa posici�n. Para usar el power down tendremos que hacer un double tap en la pantalla.</p>


**Power-Downs:**

<p>Todos los Power-downs son seleccionados de manera aleatoria dentro de una caja. Cuando coges una caja en una partida, se seleccionar� uno de estos poderes de manera aleatoria. Todos tendr�n un solo uso.</p>
<p>Si cogemos una caja teniendo un power down ya en la �mano�, se sobrescribe dicho poder.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Miss Teapot: Tetera con la cara de la protagonista de nuestro otro juego que cuando se lanza, echa t� sobre el escenario para que otro jugador se resbale y vaya m�s r�pido, por lo tanto, quede m�s lejos de poder ganar. No afecta al control de la direcci�n.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Medicina Infantil: Un frasco de medicina infantil para el catarro, de una densidad media y color anaranjado. Recuerda a un medicamento de una marca conocida que se da a los ni�os m�s peque�os cuando est�n malos. Produce un mareo al jugador que la utilice que hace que su juguete se mueva en zigzag y no pueda controlar la direcci�n durante varios segundos</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Paraca�das: Se abre una bolsita con un mini paraca�das detr�s del juguete del jugador que lance este power-down. Esto har� que dicho juguete vaya m�s lento durante unos segundos, hasta que el paraca�das se rompa.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Cohete: Lanzas un cohete hacia atr�s que hace que te defiendas contra los otros jugadores que puedan venir a tus espaldas.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>�	Brick Madness: Aparece un bloque muy parecido a los bloques de construcci�n de una conocida marca danesa de juguetes. Este bloque aparece delante del propio jugador, as� que en la mayor�a de los casos lo coger� �l mismo, pero existir� una peque�a posibilidad de que lo coja otro jugador, si est� lo suficientemente avispado.</p>

**Niveles:**

<p>	Los niveles se desarrollar�n en distintos escenarios con diferentes tem�ticas. Las diferencias de unos con otros ser�n, mayormente, claves en los obst�culos y objetos interactivos del propio mapa, as� como la est�tica entera del propio escenario.</p>

**Modos de Juego:**

<p>Distinguiremos dos modos de juego:</p>
<p>�	Entrenamiento: El jugador podr� disfrutar de todos los escenarios y niveles que tendr� el juego de manera individual. Podr� desarrollar las habilidades necesarias para garantizar su victoria frente a otros jugadores. No tendr� ninguna diferencia con el modo multijugador, salvo por la restricci�n de que jugar� un �nico jugador.</p>
<p>�	Multijugador Competitivo: Consistir� en un buscador y selector de salas donde se podr�n unir desde dos hasta seis jugadores como m�ximo. Una vez la sala est� llena, o se decida empezar una partida, se podr� elegir uno de los niveles disponibles. Una vez empezado la partida, todos los jugadores empezar�n la partida al mismo nivel, al contrario que otros juegos de carreras, y deber�n competir unos con otros para evitar ser el premio que Lucho se meter� en la boca.</p>


**Nivel 1:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Nos ponemos en la piel de un juguete lleno de nieve y con fr�o. No sabemos por qu�, pero estamos en medio de la ladera de una monta�a de los Alpes. Por la densidad de la nieve, parece que estamos en pleno invierno. Tendremos que ayudar a los intr�pidos juguetes a salir de aquel sitio tan helado y conseguir salvarse, pero cuidado, ya que solo el �ltimo ser� de verdad salvado.</p>
<p>Mientras estamos corriendo monta�a abajo nos toparemos con un mont�n de �rboles nevados, alg�n que otro mu�eco de nieve, y tambi�n restos helados que han quedado producidos por la acumulaci�n de capas de nieve que se funde y se compacta.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Tambi�n habr� que tener en cuenta que podremos ver a cierto personaje navide�o cruzando la monta�a, y ser�a muy divertido chocarse con �l. Para no perder el control y bajar de manera segura, tendremos que buscar restos de barro causados por la mezcla de la nieve con la tierra de la propia monta�a.</p>
<p>Mientras ocurre todo esto, cada juguete escuchar� en su cabeza una melod�a un tanto pegadiza, que le har� bajar la monta�a de una manera m�s relajada</p>

**Nivel 2:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Estamos en nuestro sue�o, hemos despertado en un mundo en el que absolutamente todo est� hecho de dulces; chocolate, nubes de az�car, caramelos, piruletas, etc. Pero en este mundo paradis�aco no iba a ser todo bueno, nuestros juguetes deber�n recorrer las calles de este sitio en busca de como salir de all� y volver al mundo real. Sin embargo, Lucho sabe su intenci�n, e intentar� comerse a los que lleguen primeros a la l�nea de salida del mundo, solo el �ltimo juguete se salvar�.</p>
<p>Durante la carrera, recorreremos una calle de chocolate con caramelos de colores. Podremos encontrarnos con nubes difusas de algod�n de az�car, pareces de nubes esponjosas, y multitud de caramelos, piruletas y bastones.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Tambi�n nos encontraremos con alg�n habitante de tan extra�o mundo. Son galletas. Ricas galletas que los juguetes querr�n coger para ralentizar su avance y evitar ser comidos por Lucho. Pero no solo eso, sino tambi�n ciertos ositos de gelatina dulce, parecida a la gominola, que ser�n muy pesados y har�n que nuestro jugador rebote, debido a su elasticidad. Mientras ocurre todo esto, cada juguete escuchar� en su cabeza una melod�a un tanto pegadiza, que le har� bajar la monta�a de una manera m�s relajada.</p>
<p></p>


**Nivel 3:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Lucho ha tenido una pesadilla, y los juguetes son los que sufren las consecuencias. Tienen que correr para escapar de un sitio aparentemente tenebroso. Los juguetes deber�n tener cuidado, porque del suelo salen huesos sospechosos que dan muy mal rollo.</p>
<p>Nos encontraremos una gran cantidad de �rboles sin hojas, ser� una noche fr�a y oscura. Pero lo m�s inquietante de todo es que los juguetes no ser�n los �nicos habitantes de ese mundo; no. Podremos toparnos con fantasmas que nos har�n ralentizar nuestra carrera.</p>


<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Tambi�n tendremos algunos habitantes que pasar�n por ah� en mal momento. Alg�n esqueleto que decidi� dar un paseo, pero se encontrar� con algo de jaleillo.</p>
<p>Debido a que es un sitio abandonado, habr� telara�as muy antiguas, que ser�n tan resistentes que podr�n hacer que nuestros juguetes reboten y salgan disparados hacia atr�s. Nos podremos encontrar con manchas sospechosas de color rojo, que har�n perder el control a nuestros juguetitos, ser� algo a tener en cuenta tambi�n. Mientras ocurre todo esto, cada juguete escuchar� en su cabeza una melod�a un tanto pegadiza, que le har� bajar la monta�a de una manera m�s relajada.</p>

<p></p>



**Tecnolog�as Utilizadas:**

<p>Para el desarrollo art�stico del proyecto se han usado Adobe Photoshop con licencia de estudiante, junto con otras herramientas de dibujo, como tabletas gr�ficas.</p>
<p>Para el desarrollo del modelado 3D se ha usado 3Ds Max de Autodesk con licencia de estudiante. </p>
<p>Para el desarrollo del juego, es decir, la programaci�n, se ha usado el Visual Studio 2017 y el entorno propio de Unity de C#.</p>
<p>Para el desarrollo musical se ha usado Musescore y Audacity, ambos con licencias estudiantiles</p>
<p></p>

**Equipo:**

**Rainbow Teapot Studio**

![Logotipo](Imagenes_readme/RTLogoClara.png)


<p align="center">Andrea Rodr�guez Gonz�lez- Programaci�n / Modelado 3D / RRPP</p>

<p align="center">Marcos Agudo Alarc�n - Programador / RRPP </p>

<p align="center">Celia  Merino Valladolid- Arte</p>

<p align="center">Juan Antonio Ruiz Ramirez- Ingenier�a de Sonido</p>

<p align="center">Carlos Marques Gonz�lez - Game Designer / Modelado 3D</p>

**Contacto:**

<p align="center">
     <img width="128" height="128"src="Imagenes_readme/twitterlogodown.png">
</p>


<p align="center">https://twitter.com/RainbowTeapotSt</p>

<p align="center">
     <img width="128" height="128" src="Imagenes_readme/instagram-logo1.png">
</p>


<p align="center">https://www.instagram.com/rainbowteapotst/?hl=es</p>


<p align="center">
     <img width="175" height="128" src="Imagenes_readme/450_1000.png">
</p>

<p align="center">rainbowteapotstudio@gmail.com</p>

<p align="center">
     <img width="128" height="128" src="Imagenes_readme/itch-io_150445.png">
</p>

<p align="center">RainbowTeapotStudio</p>

<p align="center">
     <img width="128" height="128" src="Imagenes_readme/patreon.png">
</p>

<p align="center">RainbowTeapotStudio</p>