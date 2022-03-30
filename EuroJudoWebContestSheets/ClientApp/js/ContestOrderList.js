const template = document.createElement('template');
template.innerHTML = `
    <div>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th id="heading" colspan="5">Tatami </th>
                </tr>
            </thead>
            <tbody id="contests">
            </tbody>
        </table>
    </div>
`;
const rowTemplate = document.createElement('template');
rowTemplate.innerHTML = `
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
`;
export class ContestOrderList extends HTMLElement {
    constructor(Tatami, contests) {
        super();
        let shadow = this.attachShadow({ mode: 'open' });
        this.shadowRoot.appendChild(template.content.cloneNode(true));
        this.shadowRoot.getElementById('heading').innerText = `Tatami ${Tatami}`;
        // Apply bootstrap 3 styles to the shadow dom
        const linkElem = document.createElement('link');
        linkElem.setAttribute('rel', 'stylesheet');
        linkElem.setAttribute('href', 'https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css');
        let contestList = this.shadowRoot.getElementById('contests');
        contests.map(function (contest) {
            let row = rowTemplate.content.cloneNode(true);
            let td = row.querySelectorAll("td");
            td[0].textContent = contest.number.toString();
            td[1].textContent = contest.short;
            td[2].textContent = contest.weight;
            td[3].textContent = contest.competitorWhite;
            td[4].textContent = contest.competitorBlue;
            contestList.appendChild(row);
        });
        shadow.appendChild(linkElem);
    }
}
window.customElements.define('contest-order-list', ContestOrderList);
