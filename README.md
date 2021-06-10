# CSI-AND-PRI
Marco de trabajo para la construcción de sistemas informáticos, de pequeña, mediana y gran escala.

Objetivo Principal: Fomentar un lenguaje ubicuo en la construcción de sistemas empresariales o de instituciones estatales.

Objetivos Secundarios:

- Reutilización de código fuente a nivel de segmentos.
- Optimización de tiempos de desarrollo.
- Escalable y fácil de mantener con el tiempo.

Permite a que cualquier ingeniero informático o analista de sistemas, ya sea experimentado o novato, pueda perfeccionar o mejorar su forma de construir sistemas de información de una forma limpia, ordenada y con el objetivo principal de fomentar el lenguaje ubicuo hacia él y a sus compañeros de equipo, colegas, partner, etc. Para lo cual consta de las siguientes capas:

-	Presentación o Cara Visible.
-	Aplicación y Dominio.
-	Datos e Infraestructura.
-	Entidades y Validaciones.
-	Pruebas.

Capa 1, Presentación o Cara Visible: esta capa se encarga de todo lo referente al muestreo de las interfaces usuarias hacia el usuario, es decir, puede corresponder a cualquier arquetipo que se estime conveniente como, por ejemplo, un arquetipo de tipo Web, de tipo Mobile, de tipo de Aplicación de Escritorio o Aplicación de Consola, etc. Lo que estime conveniente el cliente interesado. Recordad que en esta capa puede albergar 1 o muchos arquetipos, dependiendo del cliente o de la necesidad en cuestión que este tenga.

Capa 2, Aplicación y Dominio: esta capa se encarga de toda la inteligencia del sistema, es decir, de los procesos de cómputo que requiere el cliente, para lo cual esta capa se divide en dos partes, que son las siguientes:

-	Aplicación: esta se encarga de toda la fontanería de los procesos especificados por el negocio, es decir, lo que se indica al sistema lo que tiene que ejecutar primero y lo que debe ejecutar después.
-	Dominio: se encarga de albergar la sumatoria de todas las reglas de negocio definidas por el cliente, es decir, este es el lugar de instancia para que el cliente pueda discutir con el equipo de TI (Tecnología de la Información, por ejemplo, la edad mínima de ingreso al sistema, que sean todas las personas mayores de 18 años).

Capa 3, Datos e Infraestructura: se encarga de gestionar el acceso a los datos o servicios externos, por ejemplo, la comunicación de datos de SQL Server, Oracle, etc. Además, el acceso a los datos de algún servicio Web especificado.

Capa 4, Entidades y Validaciones: es responsable de albergar todos los objetos de entidades del sistema, tales como, los DTO (Data Transfer Object), Enumeraciones, Interfaces (no confundir con interfaces usuarias) y Validaciones de Interfaces usuarias.

Capa 5, Capa de Pruebas: se encarga de definir las pruebas unitarias y funcionales de los ya construidos en el sistema con el propósito de escalar un error especificado.

Para entender esto, se debe tener conocimientos técnicos del diseño guiado por el dominio.