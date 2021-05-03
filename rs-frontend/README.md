# rs-frontend
## Requirements
* This is single page app was built using `reactjs`. The computer running the project will need to have Node (at least v12.18.3) installed.
* The `config.js` file contains the paths to the rest apis. By default, it's pointing to `http://localhost:9001/RS` which should be changed accordingly if the project `rs-backend` is also changed.
* After cloning this repository, in a new terminal execute: `npm install`.
* Once all packages are installed, simply run: `npm start`.

## Notes
* By default the app will run in `http://localhost:3000`. If this is changed, then the project `rs-backend` has to be adjusted accordingly in its `appsettings.json` file to allow incoming requests from a different origin. In that case, the line `ValidOriginDomains` should be updated with a new element or the default one can be overwritten.