# 🏥 MedSync (Sistema Gestor de Pacientes)

## 📌 Descripción
Este es un sistema diseñado para la gestión de pacientes en centros médicos, desarrollado con **ASP.NET Core MVC** bajo una **Onion Architecture**.

## 🖼️ Imágenes del Proyecto

### 📌 Inicio de Sesión
![Login](https://github.com/user-attachments/assets/10e892be-de29-48e5-898f-6bec4554937f)

### 📌 Gestion de Pacientes
![Paciente](https://github.com/user-attachments/assets/a98bf82e-ea16-4695-b721-c1e63b0314d7)

### 📌 Gestion de Doctores
![Doctoers](https://github.com/user-attachments/assets/dadc0049-8304-47ea-bdfc-e9d047945be4)

### 📌 Gestion de Citas Médicas
![citas](https://github.com/user-attachments/assets/bb15fae0-ead8-470d-ba33-88112d9d4554)

### 📌 Resultado de las citas
![resultado de la cita](https://github.com/user-attachments/assets/14525c39-8ca9-4f35-83f3-3d8d4371904b)

### 📌 Gestion de Pruebas de Laboratorio
![PruebaLab](https://github.com/user-attachments/assets/ddbe4193-255d-4376-9a72-1fc3ce4baebf)

### 📌 Gestion de Resultados de las Pruebas 
![resultados](https://github.com/user-attachments/assets/a3d0e7a7-9e94-452f-8c1b-97747ba54cbb)


## 🏛️ Estructura del Proyecto

MedSync 
│── Source
│ │── Core
│ │ │── MedSync.Core.Application (Casos de uso, servicios y ViewModels)
│ │ │── MedSync.Core.Domain (Entidades y contratos - Reglas de negocio)
│ │── Infrastructure
│ │ │── MedSync.Infrastructure.Persistence (Acceso a la base de datos y repositorios)
│ │── Presentation 
│ │ │── WebApp 
│ │ │ │── MedSync.Presentation.Web (Capa de presentación - UI)

---

## 📂 Capas y Responsabilidades

### **1️⃣ MedSync.Core.Domain (Capa de Dominio - Core del Negocio)**
- Define las **entidades del sistema**, **interfaces de repositorio** y **enumeraciones**.
- Es independiente de cualquier tecnología de infraestructura.
- Contiene las **reglas de negocio puras**.

### **2️⃣ MedSync.Core.Application (Capa de Aplicación)**
- Contiene la lógica de los **casos de uso, servicios y ViewModels**.
- Proporciona interfaces para interactuar con la capa de dominio sin acceder directamente a la persistencia.
- Se comunica con los repositorios a través de la inyección de dependencias.

### **3️⃣ MedSync.Infrastructure.Persistence (Capa de Persistencia)**
- Implementa los repositorios definidos en `Domain`.
- Contiene el **DbContext y migraciones** para la base de datos.
- Aplica **eliminación lógica** (`IsActive`) en lugar de eliminar registros físicamente.

### **4️⃣ MedSync.Presentation.Web (Capa de Presentación)**
- Implementa la interfaz de usuario con **Razor y Bootstrap**.
- Expone **APIs y controladores** para la interacción con la aplicación.
- Gestiona la autenticación y autorización con **Identity**.
- Contiene middlewares y configuración general de la aplicación.

---

## 🎯 **Principios Clave**
✅ **Clean Architecture**: Separa el código en capas modulares.  
✅ **Inversión de Dependencias**: La lógica de negocio no depende de implementaciones concretas.  
✅ **Escalabilidad y Mantenibilidad**: Facilita la evolución del proyecto sin afectar otras capas.  
✅ **Seguridad y Control de Acceso**: Implementación robusta con **Identity y JWT**.  

---

## ⚙️ **Tecnologías Utilizadas**
- **ASP.NET Core MVC** para la capa web.
- **Entity Framework Core** para la persistencia de datos.
- **C# y .NET** como tecnologías principales.
- **SQL Server** como base de datos.
- **Bootstrap y Razor** para la interfaz de usuario.

---

Este sistema garantiza una **gestión eficiente y segura de los pacientes**, facilitando los procesos administrativos en centros médicos. 💡✨  
