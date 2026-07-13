# Customer Details and Private Information 

```mermaid
erDiagram
    USERS.CUSTOMER_DETAILS ||--|| USERS.PRIVATE_INFORMATION : has
    
    USERS.CUSTOMER_DETAILS {
        Guid id PK
        string first_name
        string last_name
        string suffix "optional"
        date registration_date
        char middle_initial "optional"
    }
    
    USERS.PRIVATE_INFORMATION {
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