# Task 06 - API Standards & Refactor Pack

## Original Problems
- Controller contained storage and business logic.
- POST endpoint used query/string parameters instead of request body DTO.
- Invalid data returned 200 OK with error text.
- Product used public fields instead of properties.
- No service layer existed.

## Improvements Made
- Added CreateProductRequest DTO.
- Added ProductResponse DTO.
- Moved product logic into ProductService.
- Used BadRequest for invalid input.
- Used NotFound for missing product.
- Cleaned routes to follow REST naming.

## What I Learned
Through this task, I learned how to separate concerns by moving business logic into a dedicated service layer, which makes the controller much cleaner and strictly focused on handling HTTP requests. I also learned the importance of using DTOs to define explicit contracts for request and response payloads, ensuring we only expose necessary data. Furthermore, applying standard RESTful routing conventions and returning appropriate HTTP status codes (like 400 for bad input and 404 for missing resources) makes the API professional, predictable, and easier to integrate with.

## 📸 Screenshots & Demos
> **Note to self:** Replace these placeholders with actual image links before submitting.
- **Swagger UI Overview:** `![alt text](image.png)`
- **Postman Testing:** `[Add Postman Screenshot Here]`
