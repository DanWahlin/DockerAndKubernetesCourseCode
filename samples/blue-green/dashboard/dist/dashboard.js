"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const k8s = require("@kubernetes/client-node");
const Table = require("easy-table");
const kc = new k8s.KubeConfig();
kc.loadFromDefault();
const appsV1Api = kc.makeApiClient(k8s.AppsV1Api);
const coreV1Api = kc.makeApiClient(k8s.CoreV1Api);
const roles = ['blue', 'green'];
getDeployments().catch(console.error.bind(console));
function getDeployments() {
    return __awaiter(this, void 0, void 0, function* () {
        const deploymentsRes = yield appsV1Api.listNamespacedDeployment('default');
        let deployments = [];
        for (const deployment of deploymentsRes.body.items) {
            let role = deployment.spec.template.metadata.labels.role;
            if (role && roles.includes(role)) {
                deployments.push({
                    name: deployment.metadata.name,
                    role,
                    status: deployment.status.conditions[0].status,
                    image: deployment.spec.template.spec.containers[0].image,
                    ports: [],
                    services: []
                });
            }
        }
        const servicesRes = yield coreV1Api.listNamespacedService('default');
        for (const service of servicesRes.body.items) {
            if (service.spec.selector && service.spec.selector.role && roles.includes(service.spec.selector.role)) {
                let filteredDeployments = deployments.filter(d => {
                    return d.role === service.spec.selector.role;
                });
                if (filteredDeployments) {
                    for (const d of filteredDeployments) {
                        d.ports.push(service.spec.ports[0].port);
                        d.services.push(service.metadata.name);
                    }
                }
            }
        }
        renderTable(deployments);
    });
}
function renderTable(data, showHeader = true) {
    const table = new Table();
    for (const d of data) {
        d.services.sort();
        d.ports.sort();
        table.cell('Deployment', d.name);
        table.cell('Role', d.role);
        table.cell('Status', d.status ? 'running' : 'stopped');
        table.cell('Image', d.image);
        table.cell('Ports', d.ports.join(', '));
        table.cell('Services', d.services.join(', '));
        table.newRow();
    }
    ;
    table.sort(['Role|asc']);
    if (showHeader) {
        console.log(table.toString());
    }
    else {
        console.log(table.print());
    }
}
function filterByRole(deployments, role) {
    return deployments.filter(d => d.role === role);
}
//# sourceMappingURL=dashboard.js.map