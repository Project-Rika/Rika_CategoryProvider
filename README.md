﻿# Rika_CategoryProvider

# API Dokumentation

## Skapa kategori (`CreateCategory`)

**Endpoint:** `/api/category/createcategory`  
**Metod:** `POST`

### Request Body

```json
[
    {
    "CategoryName": "string"
    }
]

````

## Hämta alla kategorier (`GetAllCategories`)

**Endpoint:** `/api/categories/GetAllCategories`  
**Metod:** `GET`

### Request Body

```json
[
    {
      "CategoryName": "string"
      "categoryId": int
    }
]

````
## Hämta en kategori (`GetOneCategory`)

**Endpoint:** `/api/category/GetOneCategory/{id}`  
**Metod:** `GET`

### Request Body

```json
[
    {
    "CategoryName": "string"
    }
]

````

## Uppdatera en kategori (`UpdateCategory`)

**Endpoint:** `/api/category/UpdateCategory`  
**Metod:** `PUT`

### Request Body

```json
[
   {
    "CategoryName": "string"
    }
]

````

## Ta bort en kategori (`DeleteCategory`)

**Endpoint:** `/api/category/DeleteCategory/{id}`  
**Metod:** `DELETE`
