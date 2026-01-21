# Auditorium Booking System

A full-stack auditorium booking and management system designed for small and medium venues.  
Supports manager approvals, multilingual UI (English/Malayalam), payment tracking, WhatsApp/email notifications, trusted institution data requests, and monthly audit reporting.

Built as a production-grade system with privacy, auditability, and mobile-first design in mind.

---

## Features

### Public
- Mobile-first booking form
- Calendar month view with booked-day indicators
- English / Malayalam language toggle
- Booking requests with WhatsApp or email contact
- Reschedule flow via secure tokenized links
- CAPTCHA and rate limiting for abuse prevention

### Manager
- Secure login (role-based access)
- Month and day calendar views with event-type color coding
- Booking approval, rejection, cancellation, and rescheduling
- Overlap detection with confirmation warnings
- Payment ledger (partial and full payments supported)
- Caterer assignment and internal notes
- Multilingual manager dashboard (English / Malayalam)

### Trusted Institutions
- Whitelisted institutions with OTP-based verification
- Secure information request flow (wedding events only)
- Manager-controlled field sharing
- Full audit trail of released information

### Automation & Audit
- WhatsApp and email notifications (status updates and reminders)
- Monthly PDF audit report generation
- Disk usage and system health monitoring
- Message delivery logs and retry handling

---

## Tech Stack

### Frontend
- Angular
- Tailwind CSS / Bootstrap
- Mobile-first responsive design
- i18n (English / Malayalam)

### Backend
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- Role-based authentication (Manager, SysAdmin)
- Quartz.NET for background jobs

### Database
- SQL Server Express

### Infrastructure
- Windows VPS (IIS)
- Cloudflare (DNS, HTTPS, CDN, Turnstile CAPTCHA)
- GitHub Actions (CI/CD)

### Messaging
- WhatsApp Business API (via provider)
- SMTP Email (fallback and audit delivery)

---

## Project Structure

auditorium-booking-system/
├── frontend/ # Angular application
├── backend/ # ASP.NET Core Web API
├── docs/ # Architecture, requirements, and design notes
├── .github/ # CI/CD workflows (GitHub Actions)
└── README.md


---

## Core Design Principles

- **Privacy First**  
  Personal data is only shared with trusted institutions after OTP verification and manager approval.  
  Only wedding events are eligible for external information requests.

- **Auditability**  
  All critical actions (approvals, payments, reschedules, and data releases) are logged and included in monthly audit reports.

- **Mobile-First UX**  
  Designed for low-bandwidth mobile networks and older users with large fonts, high contrast, and simple navigation.

- **Reliability Over Cleverness**  
  Background jobs, disk monitoring, and message retries ensure the system continues working without manual intervention.

---

## Roles

- **Public User**
  - View availability (summary only)
  - Submit booking requests
  - Reschedule bookings via secure links

- **Manager**
  - Approve/reject/reschedule bookings
  - Assign caterers
  - Record payments
  - View calendar and audit data
  - Approve trusted institution info requests

- **SysAdmin**
  - Unlock accounts
  - View system health and job status
  - Monitor disk usage and logs

---

## Local Development Setup

### Prerequisites
- Node.js (LTS)
- Angular CLI
- .NET 8 SDK
- SQL Server Express
- Git

### Backend
```bash
cd backend
dotnet restore
dotnet ef database update
dotnet run
```

API will be available at: https://localhost:5001

### Frontend

```bash
cd frontend
npm install
ng serve
```

Frontend will be available at: http://localhost:4200

### Configuration

Sensitive values should never be committed to Git.
Use environment variables or local config files for:

- Database connection strings

- WhatsApp API keys

- SMTP credentials

- JWT / cookie secrets

### Roadmap

- Core booking and approval flow (v1)

- WhatsApp/email notifications and rescheduling (v2)

- Payment ledger (v3)

- Trusted institution OTP flow (v4)

- Monthly audit PDF automation (v5)

- Production deployment with Cloudflare and CI/CD (v6)

## License

This project is licensed under the Apache License 2.0.
See the LICENSE
 file for details.

## Author

Built and maintained by Preethu Pradeep
Portfolio project and production system for auditorium operations of Royal Auditorium.
