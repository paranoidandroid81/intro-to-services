# The Schedule API

## Resources

```http
GET /schedule/
```

```http
200 Ok
Content-Type: application/json
```

```json
{
    "data": [
        { "startDate": "07777", "endDate": "383983" },
        { "startDate": "89898", "endDate": "112233" }
    ],
    "courseId": "123456"
}
