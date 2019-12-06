# Braking Down
**Idea General:**

<p align="center">
     <img src="Imagenes_readme/tabla.PNG">
</p>

**Contexto Histórico:**
<p>Europa, siglo XXI. Concretamente, el año 2017. Lucho nació en el seno de una familia de clase media europea. Vive con sus padres y su hermano mayor en un chalé a las afueras de la capital. La situación en su país es bastante buena. El gobierno ha puesto mucho empeño en la clase media, lo que hizo que familias como las de Lucho pudieran tener un nivel de vida mucho mejor que el que tenían hace 10 años.</p>

**Descripción breve del juego:**

<p>En un pequeño pueblo de Wisconsin, Lucho, un pequeño niño de un año ha decidido que es hora de jugar. Es invierno, por lo que hace mucho frío y no puede disfrutar de la compañía de sus perros en la calle. Tiene que encontrar una nueva forma de entretenimiento…</p>
<p>Buscando por su habitación, ha encontrado un montón de juguetes con ruedas y se le ha ocurrido una idea genial: “Van a hacer una carrera, pero será el último el que gane, los demás serán devorados”. Como circuito de competición ha elegido las paredes de su habitación, ¡será una carrera en caída libre!</p>
<p>Lucho tiene mucha imaginación, así que los juguetes compiten en una inmensidad de escenarios diferentes de lo más dispares, desde un mundo de chucherías, hasta el sitio donde podrían ocurrir sus peores pesadillas, pero sin perder nunca el aspecto infantil.</p>
<p>Lo que tendrán que intentar los juguetes es chocarse con todos los elementos que puedan e ir por las superficies que más le retrasen, pues no quieren ser aquellos que acaben en la boca de ese travieso bebé llenos de babas y de restos de gusanitos.</p>

**Prueba nuestro juego aquí:**

<p>Github-pages: <strong>https://rainbow-teapot.github.io/RainbowTeapotGame/</strong> </p>


**Mecánicas del juego:**
<p>El jugador deberá elegir el juguete que querrá salvar de las babas del bebé. Cuando comience la partida y todos los jugadores estén listos, habrá que hacer todo lo posible por quedar en última posición y salvarse de Lucho.</p>
<p>Para ello, tendremos que darnos de golpes con todos los obstáculos que podamos para reducir nuestra velocidad y hacer que los demás jugadores nos adelanten. Solo así podremos quedar en última posición y ganar la partida, véase la moreleja. También existirán diversos eventos dentro de cada mapa que influirán en la velocidad y dirección del juguete que manejemos.</p>
<p>Por si esto no fuera suficiente, existirán diferentes objetos que los jugadores podrán recoger para cambiar las tornas en la posición dentro de carrera.</p>
<p></p>

**Progesión del Juego:**

<p align="center">
     <img src="Imagenes_readme/Diagrama_De_Flujo.png">
</p>

**Inicio de Juego:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_Iniciar.png">
</p>

<p>La primera pantalla de nuestro juego. En esta pantalla aparecerá el título del juego con una pequeña animación, el nombre de nuestro jugador y un botón que tiene escrito Login.</p>
<p>Para cambiar el nombre simplemente tendremos que pulsar o clicar sobre el propio texto, y podremos poner el nombre que tendrá nuestro jugador durante el resto del tiempo que esté jugando al juego. Una vez tengamos nuestro nombre, pulsaremos el botón de Login, que nos llevará al menú principal.</p>




**Menú principal:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_menu_ppal.png">
</p>

<p>Nos encontraremos con el mismo titulo del juego que en la pantalla anterior. A parte tendremos dos botones, uno para cada modo de juego. El botón de arriba nos llevará al modo de entrenamiento, mientras que el de abajo, al del modo multijugador.</p>
<p>Adicionalmente, tendremos dos botones, debajo de los otros dos ya mencionados. Estos dos botones corresponden a los ajustes de juego y a los créditos. El de la izquierda, con una “i”, corresponde al apartado de créditos, mientras que el de la derecha, en azul con una rueda, nos llevará al menú de opciones.</p>

**Créditos:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_creditos.png">
</p>

<p>A modo de información adicional, se podrán ver los nombres de los desarrolladores del juego, junto con el estudio. Contendrá información acerca de la red social de éste, por si se quiere hacer algún tipo de contacto con el propio estudio, o para seguir de cerca el desarrollo del estudio. Toda esta información estará recogida dentro de un cuadradito de color diferente al del fondo.</p>
<p>Al igual que en la pantalla del menú de opciones, en la parte superior izquierda de la pantalla, tenemos un botón con forma de flecha que nos hará volver al menú principal.</p>


**Menú de Opciones:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_opciones.png">
</p>
<p>En esta pantalla podremos cambiar los ajustes necesarios para que la experiencia de juego sea lo más personalizada posible, dentro de unos estándares. Nos aparecerá un cuadrado en color verde, distinto al color del fondo, donde se recogen todas las configuraciones que podemos hacer del juego de manera general.</p>
<p>Podemos configurar el sonido del juego general, referido a la música y a los efectos; teniendo un botón diferente para ambos tipos de sonido. Estos botones simplemente apagan o encienden la música y los efectos de sonido, respectivamente.</p>
<p>Además, tenemos un botón que nos permite cambiar de idioma, entre inglés y español. Cuando aparezca la bandera de un país, indicará que para cambiar al idioma de ese país deberemos de clicar sobre la bandera.</p>
<p>Por último, en la parte superior izquierda de la pantalla, tenemos un botón con forma de flecha que nos hará volver al menú principal.</p>

**Selección de Personaje:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game.png">
</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game.png">
</p>

<p>Tanto si le damos al botón de Entrenamiento o al de Multijugador, nos llevará a la pantalla de selección del personaje, que se compondrá de dos pantallas:</p>
<p>Primero nos aparecerá un cuadradito flotando donde se podrá ver la totalidad de los personajes que tiene el jugador en cuestión. Aparecerán todos seguidos unos de otros, formando una especie de cuadrícula. En cada uno de los cuadraditos aparecerá una imagen que representará a cada uno de los personajes jugables.</p>
<p>Cuando seleccionemos el personaje que queremos usar, nos llevará a la segunda pantalla, donde podremos ver como es el personaje en 3D con su animación propia de idle. En esta pantalla también podemos girar el juguete 360 grados para poder verlo desde la perspectiva que queramos. Asimismo, podremos cambiar nuestro personaje con las flechas que aparecen a los lados del modelo. Cada vez que cambiemos de personaje, sonará el efecto de sonido propio que tiene, porque cada uno tiene el suyo.</p>
<p>En la parte superior izquierda de la pantalla, tendremos el botón con la flecha, que nos permitirá volver a la pantalla anterior de la selección de personajes. Para volver al menú principal deberemos volver a clicar sobre la flecha en esta segunda pantalla</p>
<p>Cuando hayamos decidido nuestro personaje, le daremos al botón que aparece en la parte de debajo de la pantalla, para unirnos a una sala si hay alguna con hueco, o crearemos una sala nueva en caso contrario.</p>

**Sala de espera(pre-partida):**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game.png">
</p>
<p>Esta sala nos da la información acerca de los jugadores que hay en la sala, nos pone el nombre del jugador junto con una imagen con el juguete que ha escogido. En la parte derecha de la pantalla, al lado de cada jugador, aparecerá un circulo que nos dirá si el jugador está preparado o no para jugar la partida.</p>
<p>Cuando intentamos unirnos a una sala, o incluso crearla, nos sale una pantalla para avisar al jugador que está intentando unirse, para que se eviten pensamientos de que el juego se ha quedado bloqueado.</p>
<p>En la parte de debajo de la pantalla, tendremos un botón, que nos permitirá salir de la sala en la que estamos. De manera excepcional, el jugador que haya creado la sala podrá darle al botón de jugar la partida, pero solo cuando todos los jugadores que hay en la sala hayan aceptado empezar la partida.</p>
<p></p>


**Partida:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game.png">
</p>

<p>Al comenzar una partida, irán apareciendo todos los jugadores de la sala de uno en uno en la pantalla, como si llegasen y se parasen en la línea de salida para jugar. Podemos observar que en la parte de arriba de la pantalla tenemos dos cosas: A la izquierda tenemos el hueco donde aparecerán los power-downs una vez que cojamos una caja de power-downs.</p>
<p>También en la parte de arriba, justo debajo de la cajita de los power-down, tenemos una ruedecita de ajustes, que nos llevará al menú de ajustes in game. Volviendo a la partida, en la parte de la derecha de la pantalla, siguiendo en la vista de arriba, tenemos un número que nos indica la posición en la que estamos respecto de los demás jugadores, pero no el que va primero o último en el nivel, sino en la carrera.</p>
<p>El juego se desarrolla en el escenario que se ve, pudiendo mover el personaje por toda la zona que tiene el jugador a la vista. Los bordes están decorados con objetos temáticos, junto con el resto de los objetos interactivos dentro del escenario.</p>


**Menú de Opciones In-Game:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_in_game_opciones.png">
</p>

<p>A este menú solo podremos acceder en el caso de que estemos jugando una partida. Las opciones que podemos configurar aquí son las mismas que en el menú de opciones que hay en el menú principal, exceptuando el cambio de idioma. </p>
<p>Sin embargo, al ser una partida multijugador, aunque estemos en el menú, la partida no se parará puesto que molestaría al resto de jugadores. A través de esta pantalla, podemos salirnos de la partida en cualquier momento para volver al menú principal si pulsamos el botón que tenemos debajo de los ajustes de sonido. </p>
<p>Para volver a la partida, tendremos que pulsar el botón que está encima del menú, que aparece como una flecha, al igual que en otras pantallas anteriores. </p>


**Fin del Juego:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>A esta pantalla solo podemos acceder una vez que haya acabado una partida multijugador. En la propia pantalla aparecerá la posición con la que ha quedado tu personaje dentro de la ultima carrera, y, además, un botón para volver al menú principal. </p>

**Personajes:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	La vaca paca: Juguete que lleva mucho tiempo con Lucho, al cual tiene mucho aprecio. Es una vaquita blanca con manchas negras, y unas paletas con ruedas atadas a las patas.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Patinete Molinete: Uno de los dos patines que regalaron a Lucho con 6 meses. Como de momento es muy pequeño para poder usarlos, los utiliza para jugar con ellos como si fueran coches grandes. Consiste en un patín con estética retro de los años 80 con dos filas de dos ruedas, a modo de cochecito.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Váter Manolo: Un divertido váter de juguete que echa agua cuando le das a la palanca de tirar de la cadena. El padre de Lucho le hizo una pequeña puesta a punto, y le puso cuatro ruedas a los lados para que Lucho pudiera usarlo como un coche que echa agua, ya que siempre a Lucho le ha gustado mucho este tipo de juguetes.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Teléfono Loco: Un teléfono de estilo retro de juguete, con sus botones con los números del 1 al 9, cada uno con un sonido diferente, si lo pulsamos. También tiene el propio mango del teléfono, que reproduce una melodía si se toca la combinación correcta de números. Al principio era blanco, pero Lucho le pego unas pegatinas en forma de estrella de colores, para que tuviese más estilo. Aunque él no sabe ni que es el estilo ni nada.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Narangina Carolina: Un juguetito muy curioso que fue regalado a Lucho el mismo día que los patines. Se trata de una media naranja de plástico con dos ruedas, una a cada lado, dos ojitos en la parte superior de la media naranja, y una cuerdecita con una arandela, en forma de hoja, también de plástico, la cual hace que la naranjita se mueva cuando tiramos de esta anilla. Este juguetito tiene una curiosidad y es que cuando se compró venía con un intenso olor a caramelo de naranja, lo que hizo que Lucho quisiera comérselo en un par de ocasiones. Afortunadamente, ese olor se fue perdiendo con el tiempo, y ahora Lucho prefiere jugar con el que chuparlo.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Lucho: Nuestro protagonista Es el creador y todopoderoso jefe de este juego. Quién sabe que rondará por su cabeza para que sea capaz de imaginarse tantas cosas, como las historias de cada uno de sus juguetes, y como van a interactuar unos con otros y con el entorno. Lamentablemente, no es un personaje jugable, pero tendrá controlado en todo momento la situación de sus juguetes en la partida.</p>
<p>Lucho es el segundo hijo de una familia de clase media europea. Tiene mucho interés por todo lo que tiene ruedecitas y se mueve, seguramente tendrá mucho futuro en algún trabajo que tenga que ver con vehículos con ruedas. Es un niño algo rebelde, pero por lo general se porta bien con sus padres y su hermano mayor, no es demasiado trasto. Algo dentro de los baremos normales de un niño de 2 años.</p>
<p></p>

**Controles:**

<p>El juguete se moverá de manera automática hacia abajo, nosotros solo tendremos que controlar la dirección de éste durante el recorrido.</p>
<p>En caso de jugar en un ordenador, moveremos nuestro juguete con el ratón de izquierda a derecha. Si dejamos de pulsar el botón del ratón, el personaje se quedará en la posición en la cual se haya dejado de pulsar dicho botón.</p>
<p>Si jugamos desde un dispositivo móvil, tendremos que pulsar la pantalla, y mantener el dedo para que el personaje pueda moverse. Al igual que en un ordenador con el ratón, si dejamos el pulsar la pantalla, el juguete se quedará en esa posición. Para usar el power down tendremos que hacer un double tap en la pantalla.</p>


**Power-Downs:**

<p>Todos los Power-downs son seleccionados de manera aleatoria dentro de una caja. Cuando coges una caja en una partida, se seleccionará uno de estos poderes de manera aleatoria. Todos tendrán un solo uso.</p>
<p>Si cogemos una caja teniendo un power down ya en la “mano”, se sobrescribe dicho poder.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Miss Teapot: Tetera con la cara de la protagonista de nuestro otro juego que cuando se lanza, echa té sobre el escenario para que otro jugador se resbale y vaya más rápido, por lo tanto, quede más lejos de poder ganar. No afecta al control de la dirección.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Medicina Infantil: Un frasco de medicina infantil para el catarro, de una densidad media y color anaranjado. Recuerda a un medicamento de una marca conocida que se da a los niños más pequeños cuando están malos. Produce un mareo al jugador que la utilice que hace que su juguete se mueva en zigzag y no pueda controlar la dirección durante varios segundos</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Paracaídas: Se abre una bolsita con un mini paracaídas detrás del juguete del jugador que lance este power-down. Esto hará que dicho juguete vaya más lento durante unos segundos, hasta que el paracaídas se rompa.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Cohete: Lanzas un cohete hacia atrás que hace que te defiendas contra los otros jugadores que puedan venir a tus espaldas.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>•	Brick Madness: Aparece un bloque muy parecido a los bloques de construcción de una conocida marca danesa de juguetes. Este bloque aparece delante del propio jugador, así que en la mayoría de los casos lo cogerá él mismo, pero existirá una pequeña posibilidad de que lo coja otro jugador, si está lo suficientemente avispado.</p>

**Niveles:**

<p>	Los niveles se desarrollarán en distintos escenarios con diferentes temáticas. Las diferencias de unos con otros serán, mayormente, claves en los obstáculos y objetos interactivos del propio mapa, así como la estética entera del propio escenario.</p>

**Modos de Juego:**

<p>Distinguiremos dos modos de juego:</p>
<p>•	Entrenamiento: El jugador podrá disfrutar de todos los escenarios y niveles que tendrá el juego de manera individual. Podrá desarrollar las habilidades necesarias para garantizar su victoria frente a otros jugadores. No tendrá ninguna diferencia con el modo multijugador, salvo por la restricción de que jugará un único jugador.</p>
<p>•	Multijugador Competitivo: Consistirá en un buscador y selector de salas donde se podrán unir desde dos hasta seis jugadores como máximo. Una vez la sala esté llena, o se decida empezar una partida, se podrá elegir uno de los niveles disponibles. Una vez empezado la partida, todos los jugadores empezarán la partida al mismo nivel, al contrario que otros juegos de carreras, y deberán competir unos con otros para evitar ser el premio que Lucho se meterá en la boca.</p>


**Nivel 1:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Nos ponemos en la piel de un juguete lleno de nieve y con frío. No sabemos por qué, pero estamos en medio de la ladera de una montaña de los Alpes. Por la densidad de la nieve, parece que estamos en pleno invierno. Tendremos que ayudar a los intrépidos juguetes a salir de aquel sitio tan helado y conseguir salvarse, pero cuidado, ya que solo el último será de verdad salvado.</p>
<p>Mientras estamos corriendo montaña abajo nos toparemos con un montón de árboles nevados, algún que otro muñeco de nieve, y también restos helados que han quedado producidos por la acumulación de capas de nieve que se funde y se compacta.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>También habrá que tener en cuenta que podremos ver a cierto personaje navideño cruzando la montaña, y sería muy divertido chocarse con él. Para no perder el control y bajar de manera segura, tendremos que buscar restos de barro causados por la mezcla de la nieve con la tierra de la propia montaña.</p>
<p>Mientras ocurre todo esto, cada juguete escuchará en su cabeza una melodía un tanto pegadiza, que le hará bajar la montaña de una manera más relajada</p>

**Nivel 2:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Estamos en nuestro sueño, hemos despertado en un mundo en el que absolutamente todo está hecho de dulces; chocolate, nubes de azúcar, caramelos, piruletas, etc. Pero en este mundo paradisíaco no iba a ser todo bueno, nuestros juguetes deberán recorrer las calles de este sitio en busca de como salir de allí y volver al mundo real. Sin embargo, Lucho sabe su intención, e intentará comerse a los que lleguen primeros a la línea de salida del mundo, solo el último juguete se salvará.</p>
<p>Durante la carrera, recorreremos una calle de chocolate con caramelos de colores. Podremos encontrarnos con nubes difusas de algodón de azúcar, pareces de nubes esponjosas, y multitud de caramelos, piruletas y bastones.</p>

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>También nos encontraremos con algún habitante de tan extraño mundo. Son galletas. Ricas galletas que los juguetes querrán coger para ralentizar su avance y evitar ser comidos por Lucho. Pero no solo eso, sino también ciertos ositos de gelatina dulce, parecida a la gominola, que serán muy pesados y harán que nuestro jugador rebote, debido a su elasticidad. Mientras ocurre todo esto, cada juguete escuchará en su cabeza una melodía un tanto pegadiza, que le hará bajar la montaña de una manera más relajada.</p>
<p></p>


**Nivel 3:**

<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>Lucho ha tenido una pesadilla, y los juguetes son los que sufren las consecuencias. Tienen que correr para escapar de un sitio aparentemente tenebroso. Los juguetes deberán tener cuidado, porque del suelo salen huesos sospechosos que dan muy mal rollo.</p>
<p>Nos encontraremos una gran cantidad de árboles sin hojas, será una noche fría y oscura. Pero lo más inquietante de todo es que los juguetes no serán los únicos habitantes de ese mundo; no. Podremos toparnos con fantasmas que nos harán ralentizar nuestra carrera.</p>


<p align="center">
     <img width="640" height="480" src="Imagenes_readme/Modelo_fin_juego.png">
</p>

<p>También tendremos algunos habitantes que pasarán por ahí en mal momento. Algún esqueleto que decidió dar un paseo, pero se encontrará con algo de jaleillo.</p>
<p>Debido a que es un sitio abandonado, habrá telarañas muy antiguas, que serán tan resistentes que podrán hacer que nuestros juguetes reboten y salgan disparados hacia atrás. Nos podremos encontrar con manchas sospechosas de color rojo, que harán perder el control a nuestros juguetitos, será algo a tener en cuenta también. Mientras ocurre todo esto, cada juguete escuchará en su cabeza una melodía un tanto pegadiza, que le hará bajar la montaña de una manera más relajada.</p>

<p></p>



**Tecnologías Utilizadas:**

<p>Para el desarrollo artístico del proyecto se han usado Adobe Photoshop con licencia de estudiante, junto con otras herramientas de dibujo, como tabletas gráficas.</p>
<p>Para el desarrollo del modelado 3D se ha usado 3Ds Max de Autodesk con licencia de estudiante. </p>
<p>Para el desarrollo del juego, es decir, la programación, se ha usado el Visual Studio 2017 y el entorno propio de Unity de C#.</p>
<p>Para el desarrollo musical se ha usado Musescore y Audacity, ambos con licencias estudiantiles</p>
<p></p>

**Equipo:**

**Rainbow Teapot Studio**

![Logotipo](Imagenes_readme/RTLogoClara.png)


<p align="center">Andrea Rodríguez González- Programación / Modelado 3D / RRPP</p>

<p align="center">Marcos Agudo Alarcón - Programador / RRPP </p>

<p align="center">Celia  Merino Valladolid- Arte</p>

<p align="center">Juan Antonio Ruiz Ramirez- Ingeniería de Sonido</p>

<p align="center">Carlos Marques González - Game Designer / Modelado 3D</p>

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