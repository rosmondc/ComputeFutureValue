## To setup local database project
1. Open ComputeFutureValue.Api and verify ApiConnectionString value under appsettings.json and change the server name accordinglly
2. Run Package Manager Console
3. Set default project to ComputeFutureValue.Api
4. type "dotnet ef database update" then press enter


## Razor development and API
1. Right click solution and under Common Properties-> Startup project -> select Multiple Startup Projects
2. For ComputeFutureValue.Razor and Api ComputeFutureValue.Api, set action values to Start -> click Apply then Ok
3. Press F5 to run the project


## Angular Development server and API
1. Right click solution and under Common Properties-> Startup project -> select Multiple Startup Projects
2. For ComputeFutureValue.RzoAngular and Api ComputeFutureValue.Api, set action values to Start -> click Apply then Ok
3. Press F5 to run the project



## Usefull Angular Commands
Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.


## Build
Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.


## Running unit tests
Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).
