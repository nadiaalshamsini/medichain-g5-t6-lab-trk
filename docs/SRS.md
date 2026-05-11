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
​What the system WILL NOT do:
​.Financial Transactions: The system will not handle payments or pricing, as this is the responsibility of the Revenue & Billing (REV-BIL) module.
​.External Referrals: This module does not manage the transfer of samples to external labs; that is handled by the External Referrals (REF-TRK) module.
​.Chemical Inventory: The system will not track the levels of chemical reagents or stock, which is managed by the Inventory Validation (INV-VAL) module.
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
​Section 3 (Specific Requirements): Detailed functional and non-functional requirements, including the sample lifecycle logic, automated time-tracking, and the record-locking mechanism.
---

## 2. Overall Description
### 2.1 Product Perspective
* **Instruction:** Explain how your software fits into the bigger picture. 
  * **For Subsystem Teams:** State clearly that your module is a component of a larger system. How does it interact with the master database or other modules?
  * **For the Integration Team:** Provide the high-level block diagram showing all subsystems and their connection points.

*   **2.1.1 System Interfaces:** [List the exact integration points and APIs your module exposes to, or consumes from, other teams].
*   **2.1.2 User Interfaces:** [Describe the logical characteristics of your UI. Are you following a shared design system?].
*   **2.1.3 Hardware Interfaces:** [List any required hardware, e.g., barcode scanners for labs, or state "None"].
*   **2.1.4 Software Interfaces:** [Specify OS requirements, database dependencies, or third-party libraries].
*   **2.1.5 Communications Interfaces:** [Define networking protocols used, e.g., HTTP/REST, WebSockets].
*   **2.1.6 Memory & Operational Constraints:** [State minimum RAM, storage, and normal operating assumptions].

### 2.2 Product Functions
* **Instruction:** Provide a high-level, bulleted summary of the major functions your software performs. Do not go into deep detail here (save it for Section 3).

### 2.3 User Characteristics
* **Instruction:** Who will use your specific module? (e.g., Lab Technicians, Doctors, System Admins). Describe their technical expertise level.

### 2.4 Constraints, Assumptions, and Dependencies
* **Instruction:** List any factors that limit your development (e.g., medical data privacy laws, reliance on another team finishing their API first, specific coding languages mandated).

---

## 3. Specific Requirements (Agile Approach)
* **Instruction:** This section translates traditional functional requirements into Agile User Stories. Every feature must be traceable to the project management board.

### 3.1 External Interface Requirements
* **Instruction:** Detail the exact data formats, API endpoints, and UI layouts needed for the interfaces mentioned in section 2.1.

### 3.2 System Features & User Stories
* **Instruction:** Organize your requirements by Feature. For each feature, write the underlying requirements as User Stories and link them to your GitHub Issues.

#### 3.2.1 Feature: [Insert Feature Name, e.g., Patient Registration]
*   **Description:** [Briefly describe the feature].
*   **Priority:** [High / Medium / Low].
*   **User Stories:**
    *   **Story 1:** As a [User Role], I want to [Action/Goal] so that [Benefit/Value]. 
        * *Acceptance Criteria:* [List what must be true for this to be considered 'Done'].
        * *GitHub Issue:* [Link to Issue, e.g., #12]
    *   **Story 2:** As a [User Role], I want to [Action/Goal] so that [Benefit/Value].
        * *Acceptance Criteria:* [List criteria].
        * *GitHub Issue:* [Link to Issue, e.g., #13]

#### 3.2.2 Feature: [Insert Feature Name]
*   [Repeat the structure above for all module features].

### 3.3 Performance Requirements
* **Instruction:** Specify quantitative limits. (e.g., "The module must return query results in under 2 seconds for up to 50 concurrent users").

### 3.4 Logical Database Requirements
* **Instruction:** Describe the data entities managed by your module. If you are using a shared database, specify which tables your team is responsible for. (Include ERD models in the Appendix).

### 3.5 Software System Attributes
* **Instruction:** Define the Non-Functional Requirements (NFRs) for your module:
  * **Reliability:** [Acceptable failure rates].
  * **Security:** [Authentication methods, data encryption protocols].
  * **Maintainability & Portability:** [Coding standards, documentation rules].

---

## 4. Appendices
### Appendix A: Glossary & Models
* **Instruction:** Include any Data Flow Diagrams (DFDs), Entity-Relationship Diagrams (ERDs), or detailed UI Mockups here.

### Appendix B: GitHub Traceability Checklist
* **Instruction for Team Members:** Before submitting this SRS, ensure that:
  * [ ] Every User Story in Section 3.2 has a corresponding GitHub Issue.
  * [ ] Every GitHub Issue has an appropriate label (e.g., `enhancement`, `requirement`).
  * [ ] Pull Requests reference the Issue IDs (e.g., `Closes #12`). 
