# Emergency Call System - Test Cases

## Functional Test Cases
1. **Create Emergency Call Successfully**
   - Precondition: System is running, API is accessible
   - Steps: POST /call with valid emergency data
   - Expected: 201 Created, call ID returned, call appears on map within 3 seconds

2. **Emergency Call with Location Data**
   - Steps: POST /call with GPS coordinates
   - Expected: Call appears at correct location on map

3. **Multiple Simultaneous Emergency Calls**
   - Steps: Create 5 emergency calls simultaneously
   - Expected: All calls processed and appear on map within 3 seconds

## Negative Test Cases
4. **Create Call with Missing Required Fields**
   - Steps: POST /call without deviceId or location
   - Expected: 400 Bad Request, appropriate error message

5. **Create Call with Invalid Location**
   - Steps: POST /call with out-of-bounds coordinates
   - Expected: 400 Bad Request, call not displayed on map

6. **Create Call with Malformed JSON**
   - Steps: POST /call with invalid JSON syntax
   - Expected: 400 Bad Request

## Performance Test Cases
7. **Emergency Call Display Performance**
   - Steps: Measure time from POST /call to UI map display
   - Expected: ≤ 3 seconds under normal load

8. **High Volume Call Processing**
   - Steps: Create 1000 emergency calls in 1 minute
   - Expected: All calls processed within 3 seconds, system remains responsive

## Security Test Cases
9. **Unauthorized API Access**
   - Steps: Access POST /call without authentication
   - Expected: 401 Unauthorized

10. **SQL Injection Attempt**
    - Steps: POST /call with SQL injection in fields
    - Expected: 400 Bad Request, no database errors

## End-to-End Test Cases
11. **Complete Emergency Call Flow**
    - Steps: Create call → Process → Display on map → Respond → Close
    - Expected: All steps completed successfully, status updated in real-time

12. **Call Status Synchronization**
    - Steps: Update call status via API, verify UI updates
    - Expected: UI reflects status changes within 1 second
