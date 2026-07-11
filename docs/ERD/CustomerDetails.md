# Customer Details and Private Information 

```mermaid
erDiagram
    CUSTOMER_DETAILS ||--|| PRIVATE_INFORMATION : has
    
    CUSTOMER_DETAILS {
        Guid id PK
        string first_name
        string last_name
        string suffix "optional"
        date registration_date
        char middle_initial "optional"
    }
    
    PRIVATE_INFORMATION {
        Guid customer_id PK,FK
        string email UK
        string phone_number
        string city
        string province
        string country
        string nationality
        string birth_date
    }
```