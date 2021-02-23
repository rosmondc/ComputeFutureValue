"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.httpOptions = exports.API_URL = void 0;
var http_1 = require("@angular/common/http");
exports.API_URL = "https://localhost:5001/api";
exports.httpOptions = {
    headers: new http_1.HttpHeaders({ 'Content-Type': 'application/json' })
};
//# sourceMappingURL=constants.js.map