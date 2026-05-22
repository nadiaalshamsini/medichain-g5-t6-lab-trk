# Software Requirements Specification (SRS)
## Project: Medichain - Integrated Hospital Management System (HMS)
## Module/Subsystem: Sample Tracking Module (LAB-TRK)
**Version:** 1.0  
**Date:** 2026-05-12

---

## 1. Introduction
### 1.1 Purpose
The purpose of this document is to define the functional and non-functional requirements for the Sample Tracking Module (LAB-TRK). This module is a core component of the Medichain Hospital Management System, specifically designed to monitor the lifecycle of medical samples.
​The intended audience for this document includes:
​.The Development Team: To guide the implementation of the backend logic (Node.js/PostgreSQL) and frontend interfaces.
​.The Integration Team (Team Leaders): To ensure seamless communication between LAB-TRK and other modules like Medical Approval (MED-APP).
​.Lab Administrators & Technicians: To verify that the system accurately reflects the physical laboratory workflow and security protocols.
### 1.2 Scope
* **Instruction:** The Sample Tracking Module (LAB-TRK) is a specialized subsystem within the Medichain platform designed to automate and monitor the internal movement of medical samples. The system ensures that every sample is accounted for from the moment of receipt until the final locking of the record.
  * Traceability: Providing a real-time log of the sample’s location and current processing stage (Reception, Analysis, Review).
​Quality Control: Enforcing mandatory documentation of previous stages before allowing transition to a new phase.
​Performance Monitoring: Automatically calculating the time spent in each stage and alerting administrators to any delays.
​Data Integrity: Securing the sample record once the review is complete to prevent unauthorized modifications.
  * **Crucial:** What the system WILL do:
​.Log Sample Transitions: Record every movement between laboratory stages.
​.Enforce Sequential Workflow: Prevent users from skipping stages or moving forward without proper documentation.
​.Automated Time Tracking: Start timers automatically upon entry into a new stage.
​.Alert Generation: Issue notifications if a sample exceeds the predefined time limit for a specific stage.
​.Record Locking: Permanently lock the sample data after the final review to ensure audit trail security.
​.Inter-Module Communication: Fetch material availability data and payment status from external modules to validate workflow transitions.
​What the system WILL NOT do:
​​.Financial Transactions: The system will only verify payment status from the Billing module but will not process payments or generate invoices.
​.External Referrals: This module does not manage the transfer of samples to external labs; that is handled by the External Referrals (REF-TRK) module.
​​.Chemical Inventory: The system will query the Inventory module for material availability but will not manage stock levels or reagent procurement.
​.Clinical Diagnosis: The system does not provide automated medical diagnoses; it only tracks the process of reaching those results.
### 1.3 Definitions, Acronyms, and Abbreviations
* **Instruction:** Provide a table defining all technical terms, acronyms, or domain-specific language (e.g., medical terms, API, ERP) used in this document so all teams share a common understanding.

### 1.4 References
* **Instruction:** List all referenced documents. This must include:
  * IEEE 830 Standard.
  * Links to shared architectural documents or API contracts agreed upon with the Integration Team.

### 1.5 Overview
* **Instruction:** This SRS document is organized into three main sections to provide a clear understanding of the LAB-TRK module:
​Section 1 (Introduction): Provides an overview of the module’s purpose, scope, and technical definitions.
​Section 2 (Overall Description): Describes the general factors that affect the product, including user characteristics, operating environment, and design constraints.
​Section 3 (Specific Requirements): Detailed functional and non-functional requirements, including the sample logic, automated time-tracking inter-module integration, and the record-locking mechanism.
---

## 2. Overall Description
### 2.1 Product Perspective
  * **For Subsystem Teams:** The LAB-TRK module is a core component of the larger Medichain ecosystem. It functions as a specialized unit that interacts with the master database to ensure synchronization of patient records and test results, while exchanging data with other modules to maintain a seamless clinical workflow
  * **For the Integration Team:** The high-level block diagram (located in the project folder) illustrates the interconnections between LAB-TRK and other subsystems, showing all integration points and data flow paths ,The module also relies on real-time data exchange with the Billing and Inventory subsystems to validate workflow transitions.
*   **2.1.1 System Interfaces:** The module exposes a RESTful API that enables other teams (such as Module 7) to access specific functionalities:
Status Notification: An endpoint to inform integrated modules when a sample is "Ready for Approval".
Data Exchange: A structured JSON output containing raw results, reference ranges, and the lab technician's information.
*   **2.1.2 User Interfaces:** web-based and follows the shared Medichain design language to ensure a consistent user experience. It is optimized for efficient sample entry and status monitoring via a dedicated dashboard.
*   **2.1.3 Hardware Interfaces:**​Barcode Scanners: Integrated support for scanning devices to accelerate sample intake and tracking within the lab.
​Label Printers: Compatibility with specialized laboratory printers for accurate sample identification
*   **2.1.4 Software Interfaces:** Operating System: Compatible with both Windows and Linux server environments.
​Database: Integration with the central system database for storing lab records and analytical results.
*   **2.1.5 Communications Interfaces:** The system utilizes HTTP/HTTPS protocols for all REST API communications. Data transfer is secured to maintain the confidentiality and integrity of medical information exchanged between modules.
*   **2.1.6 Memory & Operational Constraints:** ​Minimum RAM: 8 GB for the server environment to handle concurrent sample tracking and database operations.
​Storage: At least 20 GB of available disk space for the application and the growing database of medical records.
​Uptime: The system must be operational 24/7 to support laboratory shifts, with daily automated backups.

### 2.2 Product Functions
* **Instruction:** Sample Lifecycle Tracking: Monitoring the progression of medical samples from laboratory intake until results are ready for approval.
​Status Management: Automating updates for sample statuses, including "In Progress" and "Ready for Approval" notifications for other modules.
​Medical Data Handling: Managing the input and storage of raw test results and reference ranges without report generation.
​Data Integration (API): Exposing raw results, reference values, and technician names to other modules via secure endpoints.
​Security & Integrity: Implementing record-locking mechanisms and automated time-tracking for every laboratory action to ensure data accuracy.

### 2.3 User Characteristics
* **Instruction:** Lab Technicians: Primary users responsible for data entry and sample processing; they possess technical medical knowledge but require an intuitive, functional interface.
​System Administrators: Technical experts who manage system configurations, user permissions, and database maintenance.
​Integration Developers: Users from other subsystem teams who interact with the module through API documentation to facilitate system-wide communication.

### 2.4 Constraints, Assumptions, and Dependencies
* **Instruction:** Dependencies: The full functionality of the notification system depends on other Medichain modules (like Module 7) finishing their respective API integration points.
​Assumptions: It is assumed that all lab technicians have basic computer literacy and that the central Medichain server maintains a stable network connection.
​Constraints: The development is restricted to using specific technologies, primarily JavaScript for the back-end and PostgreSQL for data storage, to maintain consistency across the project.
​Compliance: All data handling must comply with standard medical privacy protocols as defined in the master project requirements.
---

## 3. Specific Requirements (Agile Approach)
* **Instruction:** This section translates traditional functional requirements into Agile User Stories. Every feature must be traceable to the project management board.

### 3.1 External Interface Requirements
* **Instruction:** Sample Status & Lifecycle Management
​These endpoints handle the tracking and progression of medical samples.
​PATCH /api/v1/samples/:id/status: Updates the current status of a sample (e.g., from "Pending" to "In Progress").
​POST /api/v1/samples/ready-for-apprval: The primary integration point that notifies external modules (like Module 7) that the sample has finished laboratory review and is "Ready for Approval".
​GET /api/v1/samples/:id/history: Retrieves the audit trail and automated time-tracking logs for a specific sample's lifecycle.
​2. Laboratory Results & Data Exchange
​These endpoints manage the raw medical data requested by the integration teams.
​POST /api/v1/samples/:id/results: Allows lab technicians to submit raw test results, reference ranges, and technician identification.
​GET /api/v1/samples/:id/results: Provides the structured JSON data (Raw Results, Reference Values, and Technician Name) to authorized external modules.
​PUT /api/v1/samples/:id/results: Used for editing existing results; this endpoint triggers the Record Locking mechanism to prevent concurrent modification errors.
​3. Administrative & System Monitoring
​Endpoints for system-wide visibility and technician management.
​GET /api/v1/samples: Returns a comprehensive list of all samples currently in the system and their real-time statuses.
​GET /api/v1/technicians/activities: Provides administrators with logs of technician actions for security and performance auditing.
​Standard Data Format (JSON)
{
  "sample_id": "string",
  "status": "ready_for_approval",
  "lab_technician": "string",
  "results": [
    {
      "test_name": "string",
      "raw_result": "string",
      "reference_range": "string",
      "unit": "string"
    }
  ],
  "timestamp": "ISO8601_DateTime"
}

3.2 System Features & User Stories
​3.2.1 Feature: Sample Intake and Tracking
​Description: This feature enables the laboratory to receive new samples and track their progress through various internal stages using precise time-tracking and documentation.
Priority: High.
​Story 1: Sample Registration
​As a Lab Technician,
​I want to register a new sample entry,
​So that its tracking lifecycle can begin in the system.
​Acceptance Criteria: The system must receive and validate the unique alphanumeric ID from Module 1, record the reception timestamp, and automatically trigger the Record Receipt Time workflow.
​GitHub Issue: #2
​Story 2: Real-Time Status Updates
​As a Lab Technician,
​I want to update the sample status in real-time,
​So that the integration team can see the current processing stage.
​Acceptance Criteria: When the technician updates the status, the system must automatically enforce Stage Documentation and Calculate Stage Time. If the calculated time exceeds predefined limits, the system triggers Issue Alerts.
​GitHub Issue: #3
​Story 3: Barcode Scanning
​As a Lab Technician,
​I want to scan a sample's barcode,
​So that I can instantly retrieve its data and current status.
​GitHub Issue: #3
​3.2.2 Feature: Secure Results Management and API Integration
​Description: Provides a secure way to input raw test results and reference ranges, exposing them to external modules through a protected API while maintaining local data integrity.
Priority: High.
​Story 1: Results Data Entry
​As a Lab Technician,
​I want to input raw laboratory test results and reference ranges into the system,
​So that the medical data is securely stored.
​Acceptance Criteria: The system must automatically enforce Record Locking while the technician is editing or entering results to prevent data conflicts from other users.
​GitHub Issue: #4
​Story 2: Data Exchange for External Approval
​As an Integration Developer (Module 7),
​I want to fetch structured JSON data for "Ready for Approval" samples,
​So that I can complete the clinical diagnostic cycle.
​GitHub Issue: #3
​Story 3: Material Availability Verification
​As a Lab Technician,
​I want to verify material availability from Module 3 before starting a test,
​So that I can ensure the analysis can be completed without interruption.
​GitHub Issue: #3
​Story 4: Financial Compliance Verification
​As a System Administrator,
​I want to block result approval if the payment status from Module 5 is "Unpaid",
​So that financial compliance is ensured before record locking.
​GitHub Issue: #3
​3.2.3 Feature: Laboratory Data Integrity
​Description: Ensuring that raw results and reference ranges are stored accurately and locked during editing to maintain strict consistency.
Priority: High.
​Story 1: Record Locking Management
​As a Lab Technician,
​I want the system to enforce strict Record Locking during results editing,
​So that no other technician can overwrite or modify my data concurrently.
​GitHub Issue: #4
​Story 2: Result Entry Timestamping
​As a System Administrator,
​I want the system to track and log the exact time each result was entered,
​So that data precision is maintained for auditing purposes.
​GitHub Issue: #5
​3.2.4 Feature: Laboratory Performance Auditing and Alerts
​Description: Provides automated audit logging and administrative tools to monitor laboratory efficiency, track processing delays, and manage alerts.
Priority: Medium.
​Story 1: View Audit Logs
​As a System Administrator,
​I want to view the automated time-tracking logs for any sample,
​So that I can audit the laboratory's performance and efficiency.
​GitHub Issue: #5
​Story 2: Delay Monitoring and Accountability
​As a System Administrator,
​I want to monitor processing delays within the laboratory stages,
​So that I can Identify the Responsible Stage for any operational bottlenecks.
​GitHub Issue: #5
​Story 3: Alert Management
​As a System Administrator,
​I want to manage system notification settings,
​So that I can configure parameters for time limits and laboratory delay alert triggers.
​GitHub Issue: #3

### 3.3 Performance Requirements
​Response Time: The system shall respond to API requests for sample data within less than 2 seconds under normal load.
​Concurrency: The module must support at least 20 concurrent lab technicians updating sample results simultaneously without performance degradation.
​Throughput: The system should be capable of processing and logging up to 500 new sample entries per day.

### 3.4 Logical Database Requirements
​Data Entities: The module is responsible for managing the Samples and LabResults entities.
​Key Tables: 
​Samples Table: Stores unique sample IDs, registration timestamps, and current status.
​Results Table: Stores raw test values, reference ranges, and the associated technician’s ID, linked to the Samples table.
​Integrity: Use of PostgreSQL foreign keys to ensure all results are linked to a valid, existing sample record
### 3.5 Software System Attributes
   **Reliability:** The system shall maintain an uptime of 99.5% during laboratory working hours, with an acceptable failure rate of less than 1% for data entry transactions.
   **Security:** Authentication: Access to the API and dashboard is restricted to authorized personnel using secure JWT (JSON Web Tokens).
​Encryption: All medical data in transit must be encrypted using HTTPS/TLS protocols.
  * **Maintainability & Portability:** Coding Standards: The back-end is developed using JavaScript with clear documentation for all API endpoints to facilitate future updates.
​Portability: The system is containerized to ensure it can be easily deployed across different server environments (Windows/Linux).
**Auditability:** The system must record the User ID and Timestamp for every stage transition to identify the personnel responsible for any delays.
​**Workflow Integrity**: The system shall enforce a sequential workflow, preventing a sample from moving to a new stage unless the previous one is fully documented.
​**Interoperability**: The module must support seamless JSON data exchange with Modules 3, 5, and 7 to maintain real-time tracking accuracy.
---

## 4. Appendices
### Appendix A: Glossary & Models
Glossary: 
​JWT: JSON Web Token, used for secure authentication.
​Reference Range: The normal range of values for a specific medical test.
​Models: (You should include your Entity-Relationship Diagram (ERD) and Data Flow Diagrams (DFDs) here as instructed in the image).
### Appendix B: GitHub Traceability Checklist
* **Instruction for Team Members:** Before submitting this SRS, ensure that:
  * [ ] Every User Story in Section 3.2 has a corresponding GitHub Issue.
  * [ ] Every GitHub Issue has an appropriate label (e.g., `enhancement`, `requirement`).
  * [ ] Pull Requests reference the Issue IDs (e.g., `Closes #12`). 
