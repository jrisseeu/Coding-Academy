"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
exports.__esModule = true;
function getSpaceNews() {
    return __awaiter(this, void 0, void 0, function () {
        var newsType, getNbr, testProd, apiUrl, response, jsonObject, headerData, tableData, theRepo;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    newsType = document.getElementById("newsType").value;
                    getNbr = document.getElementById("findVal").value;
                    testProd = document.getElementById("server").value;
                    if (testProd === "prod") {
                        apiUrl = "https://spaceflightnewsapi.net/api/v2/" + newsType + "?_limit=" + getNbr;
                    }
                    else {
                        apiUrl = "https://test.spaceflightnewsapi.net/api/v2/" + newsType + "?_limit=" + getNbr;
                    }
                    return [4 /*yield*/, fetch(apiUrl)];
                case 1:
                    response = _a.sent();
                    if (!response.ok) return [3 /*break*/, 3];
                    return [4 /*yield*/, response.json()];
                case 2:
                    jsonObject = _a.sent();
                    headerData = createTableHeader();
                    tableData = void 0;
                    for (theRepo in jsonObject) {
                        tableData += createTableData(jsonObject[theRepo].title, jsonObject[theRepo].url, jsonObject[theRepo].newsSite, jsonObject[theRepo].publishedAt, jsonObject[theRepo].summary, jsonObject[theRepo].imageUrl);
                    }
                    document.getElementById("newsInfo").innerHTML = headerData + tableData;
                    return [2 /*return*/, true];
                case 3:
                    alert("failed call" + response.status + " status text " + response.statusText);
                    return [2 /*return*/, false];
            }
        });
    });
}
//Creates the TR and TH tags for the HTML table header
function createTableHeader() {
    return "<tr><th>Title</th><th>Reference Image</th><th>News Site</th><th>Summary</th><th>Published Date</th>";
}
//Creates the HTML table with the necessary TD and TR tages
function createTableData(title, url, site, pubDate, summary, imgString) {
    var table = "<tr><td>" + formatExternalLink(url, truncateString(title, 20)) + "</td>";
    table += "<td>" + formatImage(imgString) + "</td>";
    table += "<td>" + site + "</td>";
    table += "<td>" + summary + "</td>";
    table += "<td white-space: nowrap>" + truncateDate(pubDate) + "</td></tr>";
    return table;
}
//Formats the title / link for the user to click on and open a new browser tab
function formatExternalLink(url, title) {
    return '<p><a href="' + url + '" target=_blank">"' + title + '"</a></p>';
}
//Formats the image so it can be clicked and open in a new tab
function formatImage(string) {
    var link = '<a href="' + string + '" target=_blank">';
    link += '<img src=' + string + ' style="width:150px;">';
    return link;
}
//Truncates the string based on what is passed in.  
//If the string is shorter than the value, the string is passed back.
//If the string in longer than the value, the string is truncated and three ... are added to the end
function truncateString(str, num) {
    if (str.length > num) {
        return str.slice(0, num) + "...";
    }
    else {
        return str;
    }
}
//Removes the extra characters after the date
function truncateDate(date) {
    return date.slice(0, 10);
}
//reset the user input fields
function startOver() {
    document.getElementById("newsType").value = "articles";
    document.getElementById("findVal").value = "1";
    document.getElementById("server").value = "prod";
    document.getElementById("newsInfo").innerHTML = "";
}
