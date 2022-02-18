Je n'ai pas pensé à commenter mon code donc voici quelques explications de chaque étape :

 Création d'un Scene Launcher qui contient la fonction de reload de la scene ainsi qu'un Scene Launcher setter afin de set la reference dans un scriptable object et de le mettre dans l'event ondeath du prefab joueur.
   
Création d'un entity Block suivant la même logique que l'entityFire se lançant en fonction des inputs, activant le sprite du bouclier, blockant l'entityfire grace au Canfire  et activant un boolean qui block la prise de degat du Health 
    
Création d'une clé et d'une potion ayant une classe ITakeable, la potion redonne de la vie à une entity capable de la prendre alors que la clé s'ajoute au compteur de clé du player entity La porte reconnait elle même les Player entité à porté ayant au moins une clé pour ce détruire
    
Création d'une liste de Slider dans la classe Health qui sont update à chaque changement dans la vie du joueur ( event Heal ou damage) 

Création d'un object Pool pour buller creer a partir d'un object pool universel relié aux player et aux ennemies par une reference (scriptable object, setter etc... ) 

Pas de SFX il aurait fallu faire encore des references et setter mais j'ai sauté cette étape et n'est pas eu le temps de m'en occuper

Assimilations des interrupteurs avec interface afin de les faire changes de couleurs 

Ajout d'un enum differenciant les portes à clés des porte à toogles où ces toogles ci sont dans une liste de la porte qui verifient à chaque event  s'ils sont tous sont activés en même temps afin de s'ouvrir 

Creation d'un caisse avec l'interface Itouchable et d'un random pour la créationde la potion

Création d'une reference de Screen Shake similaire aux cas vu precedemment





Le systeme de colision des fleches est vraiment étranges et peut parfois toucher et parfois non ( quand elle ne passe pas a travers toujours sans mouvement entre deux tirs)   même quand il n'y a aucun mouvement de ma part entre les deux tirs  et je n'ai pas resolu ce probleme il faut donc essayer a plusieurs endroit differents pour qu'une fleche nous inflige bien des degats et parfois même le double de ses degats