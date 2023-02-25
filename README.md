# BookStoreFinalProject
AuthorStructure :
                                    Id             number (++)
                                    Name      text
                                    Surname text
               =========================
                - CREATE    (Add)
                - READ        (GetAll | FindByName | GetById)
                - UPDATE   (Edit)
                - DELETE    (Remove)

             - Book CRUD
                

BookStructure :
                                    Id                 number (++)
                                    Name          text
                                    AuthorId      number
                                    Genre          enum
                                    PageCount number
                                    Price            number(decimal)
               =========================
                - CREATE   (Add)
                - READ     (GetAll | FindByName | GetById)
                - UPDATE   (Edit)
                - DELETE   (Remove)
