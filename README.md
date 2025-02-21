# Introduction 
Dans ce projet, nous souhaitons avoir à disposition une API permettant de consulter des informations canines, en utilisant les données fournies par l'API publique TheDogApi.

# Informations utiles
1.	Documentation Postman de TheDogApi : https://documenter.getpostman.com/view/5578104/2s935hRnak
2.  Clé API TheDogApi : live_7xoSLpaV2wkEdnX6TiStVKG1rt9xm8fmgsUqmrack3rETIDnUz3knA3OkygNajUC

# Développement
- L'API doit être développée en C#, ASP .Net Core 9.0.
- Aucune architecture en particulier n'est imposée
- Par souci de simplicité, nous allons garder les informations relatives à l'accès à l'API TheDogApi (Url & Clé API) dans le fichier de configuration appsettings.json.
- Les classes en lien avec l'API TheDogApi sont déjà créées et disponibles dans le projet TestsTechniques.TheDogApi.Models
- L'API ne doit pas être développée en Minimal APIs.
- Le controller vide est déjà créé et disponible dans le projet TestsTechniques.TheDogApi.Api, mais les routes des différents endpoint sont à créer en suivant le commentaire au dessus de chacun d'eux.

# Endpoints API à développer
- GET /dog/breeds : Retourne la liste des races de chiens.
- GET /dog/breeds/{id} : Retourne les informations d'une race de chien spécifique par son ID.
- GET /dog/images/random : Retourne une image aléatoire de chien.
- GET /dog/images/{id} : Retourne une image de chien spécifique par son ID.


# Tests Unitaires
- Les tests unitaires sont déjà écrits, et ne doivent pas être modifiés.
