# Software API


## Operations

### Adding a piece of software to the catalog
Members of the Software team can use the API to add software to the catalog of supported software.

```
Operation: AddSoftwareToCatalog
Operands:
    - The title of the software item (at least five characters long, no more than 50, required)
    - The name of the vendor that provides the software (at least five letters long, no more than 15, required)
    - Open Source or Commercial (boolean, isOpenSource, required)

The Result:

Happy Path:

Id: a unique identifier for this item.
title: the title they submitted
vendor: the vendor
isOpenSource: true or false
addedBy: the employee id of the person that added this.
```

### Designing this using HTTP:

The Resource (the URL)
The method (HTTP methods: GET | POST | PUT | DELETE)
The Representation: how do we get the data to the server, how do we represent it when we send it back.

http://authority/PATH

POST /catalog
Content-Type: application/json
Authorization: Bearer JWT

{
    "title": "Visual Studio Code",
    "vendor": "Microsoft",
    "isOpenSource": true
}


Response:

200 Ok 
Content-type: application/json

{
    "id": "da8aedb5-1ca2-480f-b972-a2746193e230",
    "title": "Visual Studio Code",
    "vendor": "Microsoft",
    "isOpenSource": true,
    "addedBy": "jeff"
}