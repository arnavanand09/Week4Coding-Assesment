
        const container = document.getElementById('tables');
        for (let n = 2; n <= 10; n++) {
            let table = document.createElement('table');
            let header = document.createElement('tr');
            let th = document.createElement('th');
            th.colSpan = 2;
            th.textContent = `Table of ${n}`;
            header.appendChild(th);
            table.appendChild(header);

            for (let i = 1; i <= 10; i++) {
                let row = document.createElement('tr');
                let td1 = document.createElement('td');
                let td2 = document.createElement('td');
                td1.textContent = `${n} x ${i}`;
                td2.textContent = n * i;
                row.appendChild(td1);
                row.appendChild(td2);
                table.appendChild(row);
            }
            container.appendChild(table);
        }